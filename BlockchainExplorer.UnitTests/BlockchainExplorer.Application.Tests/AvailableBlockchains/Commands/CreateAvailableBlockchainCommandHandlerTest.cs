using AutoMapper;
using BlockchainExplorer.Application.Contracts.Infrastructure;
using BlockchainExplorer.Application.Contracts.Persistence;
using BlockchainExplorer.Application.DTOs;
using BlockchainExplorer.Application.Features.AvailableBlockchains.Handlers.Commands;
using BlockchainExplorer.Application.Features.AvailableBlockchains.Requests.Commands;
using BlockchainExplorer.Application.Profiles;
using BlockchainExplorer.Application.Responses;
using BlockchainExplorer.Domain.Enums;
using BlockchainExplorer.UnitTests.BlockchainExplorer.Application.Tests.Common;
using BlockchainExplorer.UnitTests.Mocks;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainExplorer.UnitTests.BlockchainExplorer.Application.Tests.AvailableBlockchains.Commands
{
    public class CreateAvailableBlockchainCommandHandlerTest: InitializeUnitTest
    {
        private readonly Mock<IBlockCypherWrapper> _mockBlockCypherWrapper = new Mock<IBlockCypherWrapper>();
        private readonly CreateAvailableBlockchainCommandHandler _handler;

        public CreateAvailableBlockchainCommandHandlerTest()
        {
            _mockBlockCypherWrapper.Setup(m => m.GetAvaialableBlockChainFromBlockCypherAPI(
                It.IsAny<CoinType>())).ReturnsAsync(new Domain.Common.BlockCypherResponse()
                {
                    hash = "000000000000000000046534b7dec5a3c7bea6d6c1c94b7d51dbb4b3585d03gerc",
                    height = 360060,
                    high_fee_per_kb = 46086,
                    latest_url = "",
                    low_fee_per_kb = 0,
                    medium_fee_per_kb = 29422,
                    name = "BTC.main",
                    peer_count = 239,
                    previous_hash = "0000000000000000000221a3a70b2d9184cc13734f0589f8f5119edee6dabec2",
                    previous_url = "https://api.blockcypher.com/v1/btc/main/blocks/0000000000000000000221a3a70b2d9184cc13734f0589f8f5119edee6dabec2",
                    time = new DateTime(2023, 05, 6),
                    unconfirmed_count = 617
                });
            _handler = new CreateAvailableBlockchainCommandHandler(mockUnitOfWork.Object,
                mapper,
                _mockBlockCypherWrapper.Object);
        }

        [Fact]
        public async Task CreateAvaialableBlockChain_Valid()
        {
            int initialCountOfBlockChains = (await mockUnitOfWork.Object.BlockChain.GetAllAsync()).Count();
            var result = await _handler.Handle(new CreateAvailableBlockchainCommand()
            {
                CreateCoinType = "btc"
            }
            , CancellationToken.None);

            Assert.NotNull(result);
            Assert.IsType<BaseCommandResponse>(result);
            Assert.True(result.Success);
            Assert.True(result.Id>0);

            var allBlockChains = await mockUnitOfWork.Object.BlockChain.GetAllAsync();
            //check if it is added to repository
            Assert.Equal(initialCountOfBlockChains+1, allBlockChains.Count());
        }

        [Fact]
        public async Task CreateAvaialableBlockChain_InputEmpty_Error()
        {
            var result = await _handler.Handle(new CreateAvailableBlockchainCommand()
            {
                CreateCoinType = ""
            }
            , CancellationToken.None);
            Assert.NotNull(result);
            Assert.IsType<BaseCommandResponse>(result);
            Assert.False(result.Success);
            Assert.True(result.Id == 0);
            Assert.True(result.Errors.Count>0);
            Assert.Contains("Coin Type should not be empty", result.Message);
            var allBlockChains = await mockUnitOfWork.Object.BlockChain.GetAllAsync();
            //count not increased as it is not added
            Assert.Equal(5, allBlockChains.Count());
        }


        [Fact]
        public async Task CreateAvaialableBlockChain_InputMoreThan3Char_Error()
        {
            var result = await _handler.Handle(new CreateAvailableBlockchainCommand()
            {
                CreateCoinType = "abcde"
            }
            , CancellationToken.None);
            Assert.NotNull(result);
            Assert.IsType<BaseCommandResponse>(result);
            Assert.False(result.Success);
            Assert.True(result.Id == 0);
            Assert.True(result.Errors.Count > 0);
            Assert.Contains("Coin Type should be of of 3 characters", result.Message);
            var allBlockChains = await mockUnitOfWork.Object.BlockChain.GetAllAsync();
            //count not increased as it is not added
            Assert.Equal(5, allBlockChains.Count());
        }

        [Fact]
        public async Task CreateAvaialableBlockChain_InputUnsupportedCoin_Error()
        {
            var result = await _handler.Handle(new CreateAvailableBlockchainCommand()
            {
                CreateCoinType = "xyz"
            }
            , CancellationToken.None);
            Assert.NotNull(result);
            Assert.IsType<BaseCommandResponse>(result);
            Assert.False(result.Success);
            Assert.True(result.Id == 0);
            Assert.True(result.Errors.Count > 0);
            Assert.Contains("Only btc, eth, dash coin types are supported", result.Message);
            var allBlockChains = await mockUnitOfWork.Object.BlockChain.GetAllAsync();
            //count not increased as it is not added
            Assert.Equal(5, allBlockChains.Count());
        }
    }
}
