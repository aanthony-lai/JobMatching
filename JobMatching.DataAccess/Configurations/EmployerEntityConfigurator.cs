using JobMatching.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobMatching.DataAccess.Configurations
{
	public static class EmployerEntityConfigurator
	{
		public static ModelBuilder AddEmployerConfiguration(this ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Employer>(employer =>
			{
				employer.ToTable("Employers")
					.HasBaseType<User>();

				employer.Property(emp => emp.Id)
					.HasColumnName("Id");

				employer.Property(emp => emp.Name)
					.HasColumnName("Name")
					.IsRequired();

				employer.HasMany(emp => emp.Jobs)
					.WithOne(j => j.Employer);
			});

			return modelBuilder;
		}
	}
}