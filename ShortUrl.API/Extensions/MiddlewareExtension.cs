using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShortUrl.Data.Context;

namespace ShortUrl.API.Extensions
{
    internal static class MiddlewareExtension
    {
        internal static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            // EF: DbContext
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}