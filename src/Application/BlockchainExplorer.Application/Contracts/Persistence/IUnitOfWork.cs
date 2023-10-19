using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainExplorer.Application.Contracts.Persistence
{
    public interface IUnitOfWork
    {
        IBlockChainRepository BlockChain { get; }
        Task Save();
    }
}
