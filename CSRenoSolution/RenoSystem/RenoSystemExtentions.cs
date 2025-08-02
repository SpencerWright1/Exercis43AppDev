using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using RenoSystem.DAL;
using RenoSystem.BLL;

namespace RenoSystem
{
    public static class RenoSystemExtensions
    {
        public static IServiceCollection RenoSystemExtensionServices(this IServiceCollection services, string connection)
        {
            services.AddDbContext<RenosContext>(options => options.UseSqlServer(connection));
            services.AddTransient<JobServices>();
            services.AddTransient<SupplyServices>();
            return services;
        }
    }
}
