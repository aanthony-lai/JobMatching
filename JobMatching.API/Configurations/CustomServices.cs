using JobMatching.Application.Interfaces;
using JobMatching.Application.Services;
using JobMatching.DataAccess.Repositories;
using JobMatching.Domain.DomainServices;
using JobMatching.Domain.Interfaces;
using JobMatching.Domain.Repositories;

namespace JobMatching.API.Configurations
{
    public static class CustomServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ICandidateService, CandidateService>();
            services.AddScoped<IEmployerService, EmployerService>();
            services.AddScoped<ICompetenceService, CompetenceService>();
            services.AddScoped<IJobApplicationService, JobApplicationService>();
            services.AddScoped<IJobService, JobService>();
            services.AddScoped<IApplicantService, ApplicantService>();

            return services;
        }

        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<IJobMatchService, JobMatchService>();

            return services;
        }

        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<ICandidateRepository, CandidateRepository>();
            services.AddScoped<IEmployerRepository, EmployerRepository>();
            services.AddScoped<ICompetenceRepository, CompetenceRepository>();
            services.AddScoped<IJobApplicationRepository, JobApplicationRepository>();
            services.AddScoped<IJobRepository, JobRepository>();
            services.AddScoped<ICandidateRepository, CandidateRepository>();

            return services;
        }
    }
}
