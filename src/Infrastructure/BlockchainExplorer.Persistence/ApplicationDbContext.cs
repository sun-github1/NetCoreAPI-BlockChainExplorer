using BlockchainExplorer.Domain.Enitites;
using Microsoft.EntityFrameworkCore;

namespace BlockchainExplorer.Persistence
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        { 
        }

        public DbSet<AvailableBlockchain> AvailableBlockchains { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            modelBuilder.Entity<AvailableBlockchain>().OwnsOne(
            availableBlockchain => availableBlockchain.Response, ownedNavigationBuilder =>
            {
                ownedNavigationBuilder.ToJson();
            });
        }


    }
}
