using JobMatching.Application.Applicants;
using JobMatching.Application.Applicants.GetApplicants;
using JobMatching.Application.Authentication.ProfileCreation;
using JobMatching.Application.CandidateServices;
using JobMatching.Application.CompetenceServices;
using JobMatching.Application.EmployerServices;
using JobMatching.Application.JobServices;
using JobMatching.Application.Utilities;
using JobMatching.Domain.Authentication;
using JobMatching.Domain.Authentication.Login;
using JobMatching.Domain.Authentication.Registration;
using JobMatching.Domain.DomainServices.CriticalCompetencesMatchService;
using JobMatching.Domain.DomainServices.OverallMatchGradeService;
using JobMatching.Domain.Repositories;
using JobMatching.Infrastructure.Authentication;
using JobMatching.Infrastructure.Repositories;

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
            services.AddScoped<IApplicantMatchSummaryService, ApplicantMatchSummaryService>();
            services.AddScoped<IUserProfileCreator, UserProfileCreator>();

            services.AddScoped<ICandidateMapper, CandidateMapper>();
            services.AddScoped<IEmployerMapper, EmployerMapper>();
            services.AddScoped<IJobMapper, JobMapper>();
            services.AddScoped<IApplicantMapper, ApplicantMapper>();

            return services;
        }

        public static IServiceCollection RegisterDomainServices(this IServiceCollection services)
        {
            services.AddScoped<IOverallMatchGradeService, OverallMatchGradeService>();
            services.AddScoped<ICriticalCompetencesMatchService, CriticalCompetenceMatchService>();

            return services;
        }

        public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<ICandidateRepository, CandidateRepository>();
            services.AddScoped<IEmployerRepository, EmployerRepository>();
            services.AddScoped<ICompetenceRepository, CompetenceRepository>();
            services.AddScoped<IJobRepository, JobRepository>();
            services.AddScoped<ICandidateRepository, CandidateRepository>();
            services.AddScoped<ITokenProvider, TokenProvider>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IRegistrationService, RegistrationService>();
            services.AddScoped<IJobApplicationRepository, JobApplicationRepository>();

            return services;
        }
    }
}
