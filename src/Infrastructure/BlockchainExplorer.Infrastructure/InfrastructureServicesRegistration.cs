using BlockchainExplorer.Application.Contracts.Infrastructure;
using BlockchainExplorer.Application.Models;
using BlockchainExplorer.Infrastructure.BlockCypher;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlockchainExplorer.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<BlockCypherSettings>(configuration.GetSection("BlockCypherSettings"));
            services.AddHttpClient();
            services.AddTransient<IBlockCypherWrapper, BlockCypherWrapper>();
            return services;
        }
    }
}
