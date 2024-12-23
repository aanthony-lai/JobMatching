using JobMatching.DataAccess.Context;
using JobMatching.Infrastructure.DatabaseContext;
using Microsoft.Extensions.DependencyInjection;

namespace JobMatching.Infrastructure.DependencyInjection
{
    public static class DbContextDependencyHandler
    {
        public static IServiceCollection RegisterDbContextService(this IServiceCollection services)
        {
            services.AddIdentityCore<User>()
                .AddEntityFrameworkStores<AppDbContext>();
            
            return services;
        }
    }
}
