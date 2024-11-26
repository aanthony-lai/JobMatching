using JobMatching.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobMatching.DataAccess.Configurations
{
	public static class EmployerEntityConfigurator
	{
		public static EntityTypeBuilder<Employer> AddEmployerConfiguration(this EntityTypeBuilder<Employer> employerBuilder)
		{
			var employer = employerBuilder;

			employer.ToTable("Employers");
				//.HasBaseType<User>();
			employer.HasKey(emp => emp.EmployerId);

			employer.Property(emp => emp.EmployerId)
				.HasColumnName("Id");

			employer.Property(emp => emp.EmployerName)
				.HasColumnName("Name")
				.IsRequired();

			employer.Ignore(emp => emp.Name);

			employer.HasMany(emp => emp.Jobs)
				.WithOne(j => j.Employer);

			return employer;
		}
	}
}