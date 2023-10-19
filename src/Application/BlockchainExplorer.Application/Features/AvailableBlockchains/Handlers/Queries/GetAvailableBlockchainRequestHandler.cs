using AutoMapper;
using BlockchainExplorer.Application.Contracts.Persistence;
using BlockchainExplorer.Application.DTOs;
using BlockchainExplorer.Application.Exceptions;
using BlockchainExplorer.Application.Features.AvailableBlockchains.Requests.Queries;
using BlockchainExplorer.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainExplorer.Application.Features.AvailableBlockchains.Handlers.Queries
{
    public class GetAvailableBlockchainRequestHandler : IRequestHandler<GetAvailableBlockchainRequest, AvailableBlockchainResponse>
    {
        private readonly IBlockChainRepository _blockChainRepository;
        private readonly IMapper _mapper;
        public GetAvailableBlockchainRequestHandler(IBlockChainRepository blockChainRepository,
             IMapper mapper)
        {
            _blockChainRepository = blockChainRepository;
            _mapper = mapper;
        }
        public async Task<AvailableBlockchainResponse> Handle(GetAvailableBlockchainRequest request, 
            CancellationToken cancellationToken)
        {
            var availableBlockChain = await _blockChainRepository.GetAsync((x=>x.Id==request.Id));

            if (availableBlockChain == null)
                throw new NotFoundException("Id", request.Id);

            return new AvailableBlockchainResponse() {
                Success=true,
                Data = _mapper.Map<AvailableBlockchainDto>(availableBlockChain)
            };
        }
    }
}
