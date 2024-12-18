using JobMatching.Application.Applicants;
using JobMatching.Application.Interfaces.Mappers;
using JobMatching.Application.Interfaces.Services;
using JobMatching.Application.Services;
using JobMatching.Application.Utilities;
using JobMatching.DataAccess.Repositories;
using JobMatching.Domain.JobMatchGradeService;
using JobMatching.Domain.Repositories;

namespace JobMatching.API.Configurations
{
    public static class CustomServices
    {
        public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ICandidateService, CandidateService>();
            services.AddScoped<IEmployerService, EmployerService>();
            services.AddScoped<ICompetenceService, CompetenceService>();
            services.AddScoped<IJobService, JobService>();
            
            services.AddScoped<ICandidateMapper, CandidateMapper>();
            services.AddScoped<IEmployerMapper, EmployerMapper>();
            services.AddScoped<IJobMapper, JobMapper>();
            services.AddScoped<IApplicantMapper, ApplicantMapper>();

            return services;
        }

        public static IServiceCollection RegisterDomainServices(this IServiceCollection services)
        {
            services.AddScoped<IJobMatchService, JobMatchService>();

            return services;
        }

        public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<ICandidateRepository, CandidateRepository>();
            services.AddScoped<IEmployerRepository, EmployerRepository>();
            services.AddScoped<ICompetenceRepository, CompetenceRepository>();
            services.AddScoped<IJobRepository, JobRepository>();
            services.AddScoped<ICandidateRepository, CandidateRepository>();

            return services;
        }
    }
}
