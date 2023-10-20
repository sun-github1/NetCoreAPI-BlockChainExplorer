using BlockchainExplorer.API.Middleware;
using BlockchainExplorer.Application;
using BlockchainExplorer.Infrastructure;
using BlockchainExplorer.Persistence;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace BlockchainExplorer.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configure Serilog
            builder.Host.UseSerilog((hostContext, services, configuration) =>
            {
                // Read Serilog settings from appsettings.json
                configuration.ReadFrom.Configuration(hostContext.Configuration);
            });


            // Add services to the container.
            builder.Services.ConfigureApplicationServices();
            builder.Services.ConfigureInfrastructureServices(builder.Configuration);
            builder.Services.ConfigurePersistenceServices(builder.Configuration);

            builder.Services.AddControllers().AddJsonOptions(options => {
                options.JsonSerializerOptions.IgnoreNullValues = true;
            }); ;

            builder.Services.AddCors(o =>
            {
                o.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseMiddleware<ExceptionMiddleware>();

            // Configure the HTTP request pipeline.
            app.UseSwagger();
            app.UseSwaggerUI();
            
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors("CorsPolicy");

            // Use Serilog request logging middleware
            app.UseSerilogRequestLogging();

            app.MapControllers();

            app.Run();
        }
    }
}