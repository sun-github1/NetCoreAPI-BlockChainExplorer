using AutoMapper;
using BlockchainExplorer.Application.DTOs;
using BlockchainExplorer.Domain.Enitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainExplorer.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AvailableBlockchain, AvailableBlockchainDto>().ReverseMap();
        }
    }
}
