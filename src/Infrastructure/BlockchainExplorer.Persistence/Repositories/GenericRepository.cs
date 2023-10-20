using BlockchainExplorer.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BlockchainExplorer.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;
        public GenericRepository(ApplicationDbContext db)
        {
            _db = db;
            dbSet = _db.Set<T>();
        }

        public async Task<T> AddAsync(T entity)
        {
            var addedEntity = await dbSet.AddAsync(entity);
            return addedEntity.Entity;
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = false)
        {
            IQueryable<T> query;
            if (tracked)
            {
                query = dbSet;
            }
            else
            {
                query = dbSet.AsNoTracking();
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp.Trim());
                }
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string? includeProperties = null, bool tracked = false)
        {
            IQueryable<T> query;
            if (tracked)
            {
                query = dbSet;
            }
            else
            {
                query = dbSet.AsNoTracking();
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp.Trim());
                }
            }
            if (orderBy != null)
            {
                query = orderBy(query);
            }
            return await query.ToListAsync();
        }

    }
}
