using BlockchainExplorer.Application.Contracts.Persistence;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainExplorer.UnitTests.Mocks
{
    public class MockUnitOfWork
    {
        public static Mock<IUnitOfWork> GetUnitOfWork()
        {
            var mockUow = new Mock<IUnitOfWork>();
            var mockBlockChainRepo = MockBlockChainRepository.GetBlockChainRepository();

            mockUow.Setup(r => r.BlockChain).Returns(mockBlockChainRepo.Object);

            return mockUow;
        }
    }
}
