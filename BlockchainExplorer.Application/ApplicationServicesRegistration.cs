using BlockchainExplorer.Application.Profiles;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;
using BlockchainExplorer.Application.DTOs;
using BlockchainExplorer.Domain.Enitites;
using BlockchainExplorer.Application.Behaviors;

namespace BlockchainExplorer.Application
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(LoggingPipelineBehavior<,>));
            });

            return services;
        }
    }
}
