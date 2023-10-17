using BlockchainExplorer.Application.DTOs;
using BlockchainExplorer.Application.Features.AvailableBlockchains.Requests.Commands;
using BlockchainExplorer.Application.Features.AvailableBlockchains.Requests.Queries;
using BlockchainExplorer.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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
        public async Task<ActionResult<AvailableBlockchainDto>> GetAndStoreAvailableBlockChain([Required] string coinType)
        {
            var resultOfCreation = await _mediator.Send(new CreateAvailableBlockchainCommand() { CreateCoinType = coinType });
            if (!resultOfCreation.Success)
                throw new Exception(resultOfCreation.Message);

            var result = await _mediator.Send(new GetAvailableBlockchainRequest() { Id = resultOfCreation.Id });
            return Ok(result);
        }

        [HttpGet("hash/{hash}")]
        public async Task<ActionResult<IEnumerable<AvailableBlockchainDto>>> GetHistoryByHash(string hash)
        {
            var result = await _mediator.Send(new GetAvailableBlockchainHistoryRequest() { HashId = hash });
            return Ok(result);
        }
    }
}
