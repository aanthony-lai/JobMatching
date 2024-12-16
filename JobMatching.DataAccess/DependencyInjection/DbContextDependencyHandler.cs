using JobMatching.DataAccess.Context;
using JobMatching.DataAccess.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace JobMatching.Infrastructure.DependencyInjection
{
    public static class DbContextDependencyHandler
    {
        public static IServiceCollection RegisterDbContextService(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(AppSettingsReader.GetValue("ConnectionStrings:AppDbContext"));
            });

            return services;
        }
    }
}
