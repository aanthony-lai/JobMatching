using JobMatching.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace JobMatching.Application.DependencyInjection
{
    public static class MediatrDependencyHandler
    {
        public static IServiceCollection RegisterMediatrRequestHandlers(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CandidateService).Assembly));
            return services;
        }
    }
}
