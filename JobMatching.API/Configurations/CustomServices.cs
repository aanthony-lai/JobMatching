﻿using JobMatching.Application.Applicants;
using JobMatching.Application.Applicants.GetApplicants;
using JobMatching.Application.Candidates;
using JobMatching.Application.Interfaces.Mappers;
using JobMatching.Application.Interfaces.Services;
using JobMatching.Application.Services;
using JobMatching.Application.Utilities;
using JobMatching.Infrastructure.Repositories;
using JobMatching.Domain.Authentication;
using JobMatching.Domain.DomainServices.CriticalCompetencesMatchService;
using JobMatching.Domain.DomainServices.OverallMatchGradeService;
using JobMatching.Domain.Repositories;
using JobMatching.Infrastructure.Authentication;
using JobMatching.Domain.DomainServices.CreateCandidateService;
using JobMatching.Domain.DomainServices.CreateEmployerService;

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
            services.AddScoped<ICreateCandidateService, CreateCandidateService>();
            services.AddScoped<ICreateEmployerService, CreateEmployerService>();

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
            services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}
