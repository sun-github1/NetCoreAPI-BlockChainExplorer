using BlockchainExplorer.Application.Contracts.Persistence;
using Moq;

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
