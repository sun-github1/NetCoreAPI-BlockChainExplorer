using AutoMapper;
using BlockchainExplorer.Application.Contracts.Persistence;
using BlockchainExplorer.Application.DTOs;
using BlockchainExplorer.Application.Features.AvailableBlockchains.Requests.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainExplorer.Application.Features.AvailableBlockchains.Handlers.Queries
{
    public class GetAvailableBlockchainRequestHandler : IRequestHandler<GetAvailableBlockchainRequest, AvailableBlockchainDto>
    {
        private readonly IBlockChainRepository _blockChainRepository;
        private readonly IMapper _mapper;
        public GetAvailableBlockchainRequestHandler(IBlockChainRepository blockChainRepository,
             IMapper mapper)
        {
            _blockChainRepository = blockChainRepository;
            _mapper = mapper;
        }
        public async Task<AvailableBlockchainDto> Handle(GetAvailableBlockchainRequest request, 
            CancellationToken cancellationToken)
        {
            var availableBlockChain = await _blockChainRepository.GetAsync((x=>x.Id==request.Id));
            return _mapper.Map<AvailableBlockchainDto>(availableBlockChain);
        }
    }
}
