using BlockchainExplorer.Application.Contracts.Infrastructure;
using BlockchainExplorer.Application.Models;
using BlockchainExplorer.Infrastructure.BlockCypher;
using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.Configuration;
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
            BlockCypherSettings blockCypherSettings = new BlockCypherSettings();
            var section = configuration.GetSection("BlockCypherSettings");
            //configuration.GetSection("BlockCypherSettings")
            services.Configure<BlockCypherSettings>(configuration.GetSection("BlockCypherSettings"));
            //services.Configure<BlockCypherSettings>(opts =>
            //{
            //    new BlockCypherSettings
            //    {
            //        Token = configuration.GetSection("BlockCypherSettings:Token")?.Value,
            //        BaseUrl = configuration.GetSection("BlockCypherSettings:BaseUrl")?.Value
            //    };
            //});
            services.AddHttpClient();
            services.AddTransient<IBlockCypherWrapper, BlockCypherWrapper>();
            return services;
        }
    }
}
