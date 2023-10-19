using BlockchainExplorer.Application.Contracts.Persistence;
using BlockchainExplorer.Domain.Enitites;
using Castle.Core.Resource;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainExplorer.UnitTests.Mocks
{
    public static class MockBlockChainRepository
    {
        public static Mock<IBlockChainRepository> GetBlockChainRepository()
        {
            var availableBlockchains = new List<AvailableBlockchain>
            {
                new AvailableBlockchain
                {
                    Id = 1001,
                    CoinType=Domain.Enums.CoinType.btc,
                    CreatedAt=new DateTime(2023,10,17),//year, month, day
                    HashId="000000000000000000bf56ff4a81e399374a68344a64d6681039412de78366b8",
                    Response=new Domain.Common.BlockCypherResponse()
                    {
                        hash="000000000000000000bf56ff4a81e399374a68344a64d6681039412de78366b8",
                        height=360060,
                        high_fee_per_kb=46086,
                        last_fork_hash = "00000000000000000aa6462fd9faf94712ce1b5a944dc666f491101c996beab9",
                        last_fork_height=0,
                        latest_url="",
                        low_fee_per_kb = 0,
                        medium_fee_per_kb=29422,
                        name = "BTC.main",
                        peer_count=239,
                        previous_hash="000000000000000011c9511ae1265d34d3c16fff6e8f94380425833b3d0ae5d8",
                        previous_url="https://api.blockcypher.com/v1/btc/main/blocks/000000000000000011c9511ae1265d34d3c16fff6e8f94380425833b3d0ae5d8",
                        time=new DateTime(2023,10,16),
                        unconfirmed_count = 617
                    }
                },
                new AvailableBlockchain
                {
                   Id = 1002,
                    CoinType=Domain.Enums.CoinType.btc,
                    CreatedAt=new DateTime(2023,10,17, 5,20,12),//year, month, day
                    HashId="00000000000000000003762b7dec5a3c7bea6d6c1c94b7d51dbb4b3585d03fd",
                    Response=new Domain.Common.BlockCypherResponse()
                    {
                        hash="00000000000000000003762b7dec5a3c7bea6d6c1c94b7d51dbb4b3585d03fd",
                        height=360060,
                        high_fee_per_kb=46086,
                        last_fork_hash = "00000000000000000aa6462fd9faf94712ce1b5a944dc666f491101c996beab9",
                        last_fork_height=0,
                        latest_url="",
                        low_fee_per_kb = 0,
                        medium_fee_per_kb=29422,
                        name = "BTC.main",
                        peer_count=239,
                        previous_hash="0000000000000000000221a3a70b2d9184cc13734f0589f8f5119edee6dabec2",
                        previous_url="https://api.blockcypher.com/v1/btc/main/blocks/0000000000000000000221a3a70b2d9184cc13734f0589f8f5119edee6dabec2",
                        time=new DateTime(2023,10,15),
                        unconfirmed_count = 617
                    }
                },
                new AvailableBlockchain
                {
                    Id = 1003,
                    CoinType=Domain.Enums.CoinType.btc,
                    CreatedAt=new DateTime(2023,1,3,20,55,7),//year, month, day
                    HashId="00000000000000000002587b7dec5a3c7bea6d6c1c94b7d51dbb4b3585d05uhb",
                    Response=new Domain.Common.BlockCypherResponse()
                    {
                        hash="00000000000000000002587b7dec5a3c7bea6d6c1c94b7d51dbb4b3585d05uhb",
                        height=360060,
                        high_fee_per_kb=46086,
                        latest_url="",
                        low_fee_per_kb = 0,
                        medium_fee_per_kb=29422,
                        name = "BTC.main",
                        peer_count=239,
                        previous_hash="0000000000000000000221a3a70b2d9184cc13734f0589f8f5119edee6dabec2",
                        previous_url="https://api.blockcypher.com/v1/btc/main/blocks/0000000000000000000221a3a70b2d9184cc13734f0589f8f5119edee6dabec2",
                        time=new DateTime(2023,10,17),
                        unconfirmed_count = 617
                    }
                },
                new AvailableBlockchain
                {
                    Id = 1004,
                    CoinType=Domain.Enums.CoinType.btc,
                    CreatedAt=new DateTime(2023,1,3,22,41,17),//year, month, day
                    HashId="00000000000000000002678b7dec5a3c7bea6d6c1c94b7d51dbb4b3585d03rty",
                    Response=new Domain.Common.BlockCypherResponse()
                    {
                        hash="00000000000000000002678b7dec5a3c7bea6d6c1c94b7d51dbb4b3585d03rty",
                        height=360060,
                        high_fee_per_kb=46086,
                        latest_url="",
                        low_fee_per_kb = 0,
                        medium_fee_per_kb=29422,
                        name = "BTC.main",
                        peer_count=239,
                        previous_hash="0000000000000000000221a3a70b2d9184cc13734f0589f8f5119edee6dabec2",
                        previous_url="https://api.blockcypher.com/v1/btc/main/blocks/0000000000000000000221a3a70b2d9184cc13734f0589f8f5119edee6dabec2",
                        time=new DateTime(2023,10,17),
                        unconfirmed_count = 617
                    }
                },
                new AvailableBlockchain
                {
                    Id = 1005,
                    CoinType=Domain.Enums.CoinType.btc,
                    CreatedAt=new DateTime(2023,1,3,22,41,17),//year, month, day
                    HashId="00000000000000000002678b7dec5a3c7bea6d6c1c94b7d51dbb4b3585d03rty",
                    Response=new Domain.Common.BlockCypherResponse()
                    {
                        hash="00000000000000000002678b7dec5a3c7bea6d6c1c94b7d51dbb4b3585d03rty",
                        height=360060,
                        high_fee_per_kb=46086,
                        latest_url="",
                        low_fee_per_kb = 0,
                        medium_fee_per_kb=29422,
                        name = "BTC.main",
                        peer_count=239,
                        previous_hash="0000000000000000000221a3a70b2d9184cc13734f0589f8f5119edee6dabec2",
                        previous_url="https://api.blockcypher.com/v1/btc/main/blocks/0000000000000000000221a3a70b2d9184cc13734f0589f8f5119edee6dabec2",
                        time=new DateTime(2023,10,17),
                        unconfirmed_count = 617
                    }
                }
            };

            var mockRepo = new Mock<IBlockChainRepository>();

            Expression<Func<string, bool>> testExpression = binding => (binding == "Testing Framework");
            //mockRepo.Setup(r => r.GetAllAsync(It.IsAny<Expression<Func<AvailableBlockchain, bool>>>()
            //    , It.IsAny<Func<IQueryable<AvailableBlockchain>, IOrderedQueryable<AvailableBlockchain>>>()
            //    , It.IsAny<string>()
            //    , It.IsAny<bool>()
            //    )).ReturnsAsync(new List<AvailableBlockchain>());
            _ = mockRepo.Setup(r => r.GetAllAsync(It.IsAny<Expression<Func<AvailableBlockchain, bool>>>()
                , It.IsAny<Func<IQueryable<AvailableBlockchain>, IOrderedQueryable<AvailableBlockchain>>>()
                , It.IsAny<string>()
                , It.IsAny<bool>()
                )).ReturnsAsync(
                 (Expression<Func<AvailableBlockchain, bool>> filterExpression,
                    Func<IQueryable<AvailableBlockchain>, IOrderedQueryable<AvailableBlockchain>> orderByExprssionl,
                    string includes,
                    bool tracking) =>
                 {
                     if (filterExpression == null)
                         return availableBlockchains; 
                     var queryable = availableBlockchains.AsQueryable();
                     queryable=queryable.Where(filterExpression);
                     if (orderByExprssionl != null)
                         queryable = orderByExprssionl(queryable);

                    var result = queryable.ToList();
                     return result;
                 });

            _ = mockRepo.Setup(r => r.GetAsync(It.IsAny<Expression<Func<AvailableBlockchain, bool>>>()
                , It.IsAny<string>()
                , It.IsAny<bool>()
                )).ReturnsAsync((Expression<Func<AvailableBlockchain, bool>> filterExpression,
                    string includes,
                    bool tracking) =>
                {
                    return availableBlockchains.AsQueryable().FirstOrDefault(filterExpression);
                });

            _ = mockRepo.Setup(r => r.AddAsync(It.IsAny<AvailableBlockchain>())).ReturnsAsync(
                (AvailableBlockchain inputTestData) =>
                {
                    inputTestData.Id=availableBlockchains.Max(x => x.Id)+1;
                    availableBlockchains.Add(inputTestData);
                    return inputTestData;
                });

            return mockRepo;

        }
    }
}
