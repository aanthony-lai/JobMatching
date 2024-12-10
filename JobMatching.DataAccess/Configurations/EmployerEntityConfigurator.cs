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
					.HasKey(emp => emp.Id);

				employer.Property(emp => emp.Id)
					.HasColumnName("Id");

				employer.Property(emp => emp.Name)
					.HasColumnName("Name")
					.IsRequired();

				employer.HasMany(emp => emp.Jobs)
					.WithOne(j => j.Employer)
					.HasForeignKey(j => j.EmployerId);

				employer.HasOne(emp => emp.User)
					.WithOne()
					.HasForeignKey<Employer>(emp => emp.UserId);

				employer.OwnsOne(emp => emp.MetaData, metaDataBuilder =>
				{
					metaDataBuilder.Property(md => md.CreatedAt)
						.HasColumnName("CreatedAt")
						.IsRequired();
					metaDataBuilder.Property(md => md.UpdatedAt)
						.HasColumnName("UpdatedAt")
						.IsRequired();
					metaDataBuilder.Property(md => md.IsDeleted)
						.HasColumnName("IsDeleted")
						.IsRequired();
				});
			});

			return modelBuilder;
		}
	}
}