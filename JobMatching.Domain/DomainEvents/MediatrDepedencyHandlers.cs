using Microsoft.Extensions.DependencyInjection;

namespace JobMatching.Domain.DomainEvents
{
    public static class MediatrDepedencyHandlers
    {
        public static IServiceCollection RegisterHandlers(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(MediatrDepedencyHandlers).Assembly));

            return services;
        }
    }
}
