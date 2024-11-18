using JobMatching.DataAccess.Context;
using JobMatching.DataAccess.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace JobMatching.DataAccess.DependencyInjection
{
	public static class DbContextService
	{
		public static IServiceCollection AddDbContextService(this IServiceCollection service)
		{
			service.AddDbContext<AppDbContext>(options =>
			{
				options.UseSqlServer(AppSettingsReader.GetValue("ConnectionStrings:AppDbContext"));
			});

			return service;
		}
	}
}
