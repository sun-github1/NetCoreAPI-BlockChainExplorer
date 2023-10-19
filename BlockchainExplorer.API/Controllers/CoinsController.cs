using BlockchainExplorer.Application.Features.AvailableBlockchains.Requests.Commands;
using BlockchainExplorer.Application.Features.AvailableBlockchains.Requests.Queries;
using BlockchainExplorer.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BlockchainExplorer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoinsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CoinsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{coinType}")]
        public async Task<ActionResult<AvailableBlockchainResponse>> GetAndStoreAvailableBlockChain([Required] string coinType)
        {
            var resultOfCreation = await _mediator.Send(new CreateAvailableBlockchainCommand() { CreateCoinType = coinType });
            if (!resultOfCreation.Success)
                throw new Exception(resultOfCreation.Errors?.Count>0 ?string.Join(", ", resultOfCreation.Errors): "");

            var result = await _mediator.Send(new GetAvailableBlockchainRequest() { Id = resultOfCreation.Data.Id });
            return Ok(result);
        }

        [HttpGet("hash/{hash}")]
        public async Task<ActionResult<GetAvailableBlockchainHistoryResponse>> GetHistoryByHash(string hash)
        {
            var result = await _mediator.Send(new GetAvailableBlockchainHistoryRequest() { HashId = hash });
            return Ok(result);
        }
    }
}
