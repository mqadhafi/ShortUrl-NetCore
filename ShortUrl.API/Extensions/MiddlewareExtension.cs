using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShortUrl.Domain.Context;
using ShortUrl.Query.Factories;
using ShortUrl.Query.Factories.Contract;

namespace ShortUrl.API.Extensions
{
    internal static class MiddlewareExtension
    {
        internal static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            // EF: DbContext
            // Used for CommandHandler
            services.AddDbContext<ApplicationContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Dapper: Connection Factory
            // Used for QueryHandler
            services.AddScoped<IConnectionFactory>(_ =>
                new SqlServerConnectionFactory(configuration.GetConnectionString("DefaultConnection")));
        }

        internal static void ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
        }
    }
}