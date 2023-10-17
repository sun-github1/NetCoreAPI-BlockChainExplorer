using AutoMapper;
using BlockchainExplorer.Application.DTOs;
using BlockchainExplorer.Application.DTOs.Common;
using BlockchainExplorer.Domain.Common;
using BlockchainExplorer.Domain.Enitites;


namespace BlockchainExplorer.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AvailableBlockchain, AvailableBlockchainDto>().ReverseMap();
            CreateMap<BlockCypherResponse, BlockCypherResponseDto>().ReverseMap();
        }
    }
}
