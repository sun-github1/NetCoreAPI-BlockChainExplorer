using BlockchainExplorer.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainExplorer.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public IBlockChainRepository BlockChain { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            BlockChain = new BlockChainRepository(_db);
        }

        public async Task Save()
        {
           await _db.SaveChangesAsync();
        }
    }
}
