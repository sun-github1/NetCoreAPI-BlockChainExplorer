using BlockchainExplorer.Application.DTOs;
using BlockchainExplorer.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainExplorer.Application.Features.AvailableBlockchains.Requests.Queries
{
    public class GetAvailableBlockchainHistoryRequest: IRequest<GetAvailableBlockchainHistoryResponse>
    {
        public string HashId { get; set; }
    }
}
