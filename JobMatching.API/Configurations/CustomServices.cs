using JobMatching.Application.Interfaces;
using JobMatching.Application.Services;
using JobMatching.DataAccess.Repositories;

namespace JobMatching.API.Configurations
{
	public static class CustomServices
	{
		public static IServiceCollection AddCustomService(this IServiceCollection service)
		{
			service.AddScoped<IUserRepository, UserRepository>();
			service.AddScoped<IEmployerRepository, EmployerRepository>();
			service.AddScoped<IEmployerService, EmployerService>();
			service.AddScoped<IUserService, UserService>();

			return service;
		}
	}
}
