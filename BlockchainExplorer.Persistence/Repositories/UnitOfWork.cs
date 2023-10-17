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
        private readonly ApplicationDbContext _context;
        private IBlockChainRepository _blockChainRepository;
        public UnitOfWork(ApplicationDbContext db)
        {
            _context = db;
        }
        public IBlockChainRepository BlockChain => _blockChainRepository ??= new BlockChainRepository(_context);

        public async Task Save()
        {
           await _context.SaveChangesAsync();
        }
    }
}
