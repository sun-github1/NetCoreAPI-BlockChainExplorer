using BlockchainExplorer.Application.Contracts.Persistence;
using BlockchainExplorer.Domain.Enitites;

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
