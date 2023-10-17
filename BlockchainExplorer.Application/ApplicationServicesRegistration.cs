using BlockchainExplorer.Application.Profiles;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;

namespace BlockchainExplorer.Application
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            return services;
        }
    }
}
