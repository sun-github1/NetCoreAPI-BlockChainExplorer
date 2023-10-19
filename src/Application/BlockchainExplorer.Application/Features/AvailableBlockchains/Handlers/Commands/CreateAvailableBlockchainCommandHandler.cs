using AutoMapper;
using BlockchainExplorer.Application.Contracts.Infrastructure;
using BlockchainExplorer.Application.Contracts.Persistence;
using BlockchainExplorer.Application.DTOs;
using BlockchainExplorer.Application.DTOs.Validators;
using BlockchainExplorer.Application.Exceptions;
using BlockchainExplorer.Application.Features.AvailableBlockchains.Requests.Commands;
using BlockchainExplorer.Application.Responses;
using BlockchainExplorer.Domain.Enitites;
using BlockchainExplorer.Domain.Enums;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BlockchainExplorer.Application.Features.AvailableBlockchains.Handlers.Commands
{
    public class CreateAvailableBlockchainCommandHandler :
        IRequestHandler<CreateAvailableBlockchainCommand, AvailableBlockchainResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IBlockCypherWrapper _blockCypherWrapper;
        private readonly ILogger<CreateAvailableBlockchainCommandHandler> _logger;
        public CreateAvailableBlockchainCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IBlockCypherWrapper blockCypherWrapper,
            ILogger<CreateAvailableBlockchainCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _blockCypherWrapper = blockCypherWrapper;
            _logger = logger;
        }
        public async Task<AvailableBlockchainResponse> Handle(CreateAvailableBlockchainCommand request,
            CancellationToken cancellationToken)
        {
            var response = new AvailableBlockchainResponse();
            var validator = new CoinTypeValidator();
            var validationResult = await validator.ValidateAsync(request.CreateCoinType);
            if (validationResult.IsValid)
            {
                if (!Enum.TryParse(request.CreateCoinType, true, out CoinType resultCoinType))
                    throw new BadRequestException("Invalid CoinType");
                var serviceResponse = await _blockCypherWrapper.GetAvaialableBlockChainFromBlockCypherAPI(resultCoinType);
                if (serviceResponse != null)
                {
                    var newblockChain = new AvailableBlockchain
                    {
                        CoinType = resultCoinType,
                        CreatedAt = DateTime.UtcNow,
                        HashId = serviceResponse.hash,
                        Response = serviceResponse
                    };
                    var result = await _unitOfWork.BlockChain.AddAsync(newblockChain);
                    await _unitOfWork.Save();
                    response.Success = true;
                    response.Data = _mapper.Map<AvailableBlockchainDto>(result);
                    return response;
                }
            }
            return new AvailableBlockchainResponse()
            {
                Success = false,
                Errors = validationResult?.Errors?.Count > 0 ?
                    validationResult.Errors.Select(q => q.ErrorMessage).ToList() :
                    new List<string>() { "BlockChain Creation Failed" }
            };

        }
    }
}
