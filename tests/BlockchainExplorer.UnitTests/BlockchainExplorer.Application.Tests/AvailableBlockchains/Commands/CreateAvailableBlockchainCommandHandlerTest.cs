using BlockchainExplorer.Application.Contracts.Infrastructure;
using BlockchainExplorer.Application.Features.AvailableBlockchains.Handlers.Commands;
using BlockchainExplorer.Application.Features.AvailableBlockchains.Requests.Commands;
using BlockchainExplorer.Application.Responses;
using BlockchainExplorer.Domain.Enums;
using BlockchainExplorer.UnitTests.Common;
using Microsoft.Extensions.Logging;
using Moq;


namespace BlockchainExplorer.UnitTests.BlockchainExplorer.Application.Tests.AvailableBlockchains.Commands
{
    public class CreateAvailableBlockchainCommandHandlerTest: UnitTestInitializer
    {
        private readonly Mock<IBlockCypherWrapper> _mockBlockCypherWrapper = new Mock<IBlockCypherWrapper>();
        private readonly CreateAvailableBlockchainCommandHandler _handler;
        private Mock<ILogger<CreateAvailableBlockchainCommandHandler>> _mockLogger = new
            Mock<ILogger<CreateAvailableBlockchainCommandHandler>>();
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
                _mockBlockCypherWrapper.Object,
                _mockLogger.Object);
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
            Assert.IsType<AvailableBlockchainResponse>(result);
            Assert.True(result.Success);
            Assert.True(result.Data?.Id>0);

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
            Assert.IsType<AvailableBlockchainResponse>(result);
            Assert.False(result.Success);
            Assert.Null(result.Data);
            Assert.True(result.Errors?.Any(i=>i=="Coin Type should not be empty"));
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
            Assert.IsType<AvailableBlockchainResponse>(result);
            Assert.False(result.Success);
            Assert.Null(result.Data);
            Assert.True(result.Errors?.Any(i => i.Contains("Coin Type can be max of 4 characters")));
            var allBlockChains = await mockUnitOfWork.Object.BlockChain.GetAllAsync();
            //count not increased as it is not added
            Assert.Equal(5, allBlockChains.Count());
        }


        [Fact]
        public async Task CreateAvaialableBlockChain_InputLessThan3Char_Error()
        {
            var result = await _handler.Handle(new CreateAvailableBlockchainCommand()
            {
                CreateCoinType = "ab"
            }
            , CancellationToken.None);
            Assert.NotNull(result);
            Assert.IsType<AvailableBlockchainResponse>(result);
            Assert.False(result.Success);
            Assert.Null(result.Data);
            Assert.True(result.Errors?.Any(i => i.Contains("Coin Type should be min of of 3 characters")));
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
            Assert.IsType<AvailableBlockchainResponse>(result);
            Assert.False(result.Success);
            Assert.Null(result.Data);
            Assert.True(result.Errors?.Any(i => i.Contains("Only btc, eth, dash coin types are supported")));
            var allBlockChains = await mockUnitOfWork.Object.BlockChain.GetAllAsync();
            //count not increased as it is not added
            Assert.Equal(5, allBlockChains.Count());
        }
    }
}
