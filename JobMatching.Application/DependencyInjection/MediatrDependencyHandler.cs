using JobMatching.Application.Applicants.GetApplicants;
using Microsoft.Extensions.DependencyInjection;

namespace JobMatching.Application.DependencyInjection
{
    public static class MediatrDependencyHandler
    {
        public static IServiceCollection RegisterMediatrRequestHandlers(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetApplicantsMatchSummaryHandler).Assembly));
            return services;
        }
    }
}
