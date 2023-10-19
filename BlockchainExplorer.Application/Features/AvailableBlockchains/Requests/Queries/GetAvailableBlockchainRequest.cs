using BlockchainExplorer.Application.DTOs;
using BlockchainExplorer.Application.Responses;
using BlockchainExplorer.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainExplorer.Application.Features.AvailableBlockchains.Requests.Queries
{
    public class GetAvailableBlockchainRequest: IRequest<AvailableBlockchainResponse>
    {
        public int Id { get; set; }
    }
}
