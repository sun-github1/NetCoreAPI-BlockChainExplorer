using AutoMapper;
using BlockchainExplorer.Application.Contracts.Persistence;
using BlockchainExplorer.Application.DTOs;
using BlockchainExplorer.Application.DTOs.Validators;
using BlockchainExplorer.Application.Exceptions;
using BlockchainExplorer.Application.Features.AvailableBlockchains.Requests.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainExplorer.Application.Features.AvailableBlockchains.Handlers.Queries
{
    public class GetAvailableBlockchainHistoryRequestHandler :
        IRequestHandler<GetAvailableBlockchainHistoryRequest, List<AvailableBlockchainDto>>
    {
        private readonly IBlockChainRepository _blockChainRepository;
        private readonly IMapper _mapper;
        public GetAvailableBlockchainHistoryRequestHandler(IBlockChainRepository blockChainRepository,
             IMapper mapper)
        {
            _blockChainRepository = blockChainRepository;
            _mapper = mapper;
        }
        public async Task<List<AvailableBlockchainDto>> Handle(GetAvailableBlockchainHistoryRequest request,
            CancellationToken cancellationToken)
        {
            var validator = new HashIdValidator(_blockChainRepository);
            var validationResult = await validator.ValidateAsync(request.HashId);
            if (!validationResult.IsValid)
            {
                if(string.IsNullOrEmpty(request.HashId))
                    throw new ValidationException(validationResult);
                else
                    throw new NotFoundException("HashId", request.HashId);
            }

            var listOfBlockchains = await _blockChainRepository.GetAllAsync(
            (p => p.HashId == request.HashId),
            (o => o.OrderByDescending(c => c.CreatedAt)));

            return _mapper.Map<List<AvailableBlockchainDto>>(listOfBlockchains);

        }
    }
}
