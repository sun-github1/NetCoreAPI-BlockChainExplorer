using BlockchainExplorer.API.Middleware;
using BlockchainExplorer.Application;
using BlockchainExplorer.Infrastructure;
using BlockchainExplorer.Persistence;
using Microsoft.Extensions.Configuration;


namespace BlockchainExplorer.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.ConfigureApplicationServices();
            builder.Services.ConfigureInfrastructureServices(builder.Configuration);
            builder.Services.ConfigurePersistenceServices(builder.Configuration);

            builder.Services.AddControllers();

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

            app.MapControllers();

            app.Run();
        }
    }
}