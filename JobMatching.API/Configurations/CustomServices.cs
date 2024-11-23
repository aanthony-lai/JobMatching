using JobMatching.Application.Interfaces;
using JobMatching.Application.Services;
using JobMatching.DataAccess.Repositories;
using JobMatching.Domain.DomainServices;
using JobMatching.Domain.Interfaces;

namespace JobMatching.API.Configurations
{
	public static class CustomServices
	{
		public static IServiceCollection AddApplicationLayerServices(this IServiceCollection services)
		{
			services.AddScoped<IUserRepository, UserRepository>();
			services.AddScoped<IEmployerRepository, EmployerRepository>();

			services.AddScoped<IEmployerService, EmployerService>();
			services.AddScoped<IUserService, UserService>();

			services.AddScoped<ICompetenceRepository, CompetenceRepository>();
			services.AddScoped<ICompetenceService, CompetenceService>();

			services.AddScoped<IJobApplicationRepository, JobApplicationRepository>();
			services.AddScoped<IJobApplicationService, JobApplicationService>();

			services.AddScoped<IJobRepository, JobRepository>();
			services.AddScoped<IJobService, JobService>();

			return services;
		}

		public static IServiceCollection AddDomainServices(this IServiceCollection services)
		{
			services.AddScoped<IJobMatchService, JobMatchService>();

			return services;
		}
	}
}
