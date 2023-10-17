using BlockchainExplorer.Domain.Common;
using BlockchainExplorer.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainExplorer.Application.Contracts.Infrastructure
{
    public interface IBlockCypherWrapper
    {
        //call API
        Task<BlockCypherResponse> GetAvaialableBlockChainByCoin(CoinType coinType);
    }
}
