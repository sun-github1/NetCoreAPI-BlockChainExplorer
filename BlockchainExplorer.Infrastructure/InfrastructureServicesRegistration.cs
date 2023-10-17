using BlockchainExplorer.Application.Contracts.Infrastructure;
using BlockchainExplorer.Application.Models;
using BlockchainExplorer.Infrastructure.BlockCypher;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainExplorer.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services, 
            IConfiguration configuration)
        {
            services.Configure<BlockCypherSettings>(opts => configuration.GetSection("BlockCypherSettings"));
            //services.AddHttpClient<IBlockCypherWrapper, BlockCypherWrapper>();
            services.AddHttpClient();
            services.AddTransient<IBlockCypherWrapper, BlockCypherWrapper>();
            return services;
        }
    }
}
