using BlockchainExplorer.Application.Contracts.Persistence;
using BlockchainExplorer.Domain.Enitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainExplorer.Persistence.Repositories
{
    public class BlockChainRepository : GenericRepository<AvailableBlockchain>, IBlockChainRepository
    {
        private readonly ApplicationDbContext _db;
        public BlockChainRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
