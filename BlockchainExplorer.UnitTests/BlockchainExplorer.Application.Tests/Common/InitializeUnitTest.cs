using AutoMapper;
using BlockchainExplorer.Application.Contracts.Persistence;
using BlockchainExplorer.Application.Profiles;
using BlockchainExplorer.UnitTests.Mocks;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainExplorer.UnitTests.BlockchainExplorer.Application.Tests.Common
{
    public class InitializeUnitTest
    {
        public readonly IMapper mapper;
        public readonly Mock<IUnitOfWork> mockUnitOfWork;
        public InitializeUnitTest()
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
