using JobMatching.Infrastructure.Context;
using JobMatching.Infrastructure.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace JobMatching.Infrastructure.DependencyInjection
{
    public static class DbContextDependencyHandler
    {
        public static IServiceCollection RegisterDbContextService(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(o =>
            {
                o.UseSqlServer(AppSettingsReader.GetValue("ConnectionStrings:AppDbContext"));
            });

            return services;
        }
    }
}
