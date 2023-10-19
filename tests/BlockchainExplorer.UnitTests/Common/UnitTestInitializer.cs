using AutoMapper;
using BlockchainExplorer.Application.Contracts.Persistence;
using BlockchainExplorer.Application.Profiles;
using BlockchainExplorer.UnitTests.Mocks;
using Moq;

namespace BlockchainExplorer.UnitTests.Common
{
    public class UnitTestInitializer
    {
        public readonly IMapper mapper;
        public readonly Mock<IUnitOfWork> mockUnitOfWork;
        public UnitTestInitializer()
        {
            mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            mapper = mapperConfig.CreateMapper();
        }
    }
}
