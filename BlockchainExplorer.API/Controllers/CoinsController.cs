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

        [HttpGet]
        public async Task<ActionResult<AvailableBlockchainDto>> GetAndStoreAvailableBlockChain([Required] string coinType)
        {
            if (Enum.TryParse(coinType, true, out CoinType resultCointType))
            {
                var result = await _mediator.Send(new CreateAvailableBlockchainCommand() { CreateCoinType = resultCointType });
                return Ok(result);
            }
            else
            {
                return BadRequest("Invalid Coin Type");
            }
        }

        [HttpGet("{hash}")]
        public async Task<ActionResult<IEnumerable<AvailableBlockchainDto>>> GetHistoryByHash(string hash)
        {
            var result = await _mediator.Send(new GetAvailableBlockchainHistoryRequest() { HashId = hash });
            return Ok(result);
        }
    }
}
