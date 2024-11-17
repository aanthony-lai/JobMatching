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

			employer.ToTable("emp_employers")
				.HasKey(emp => emp.EmployerId);

			employer.Property(emp => emp.EmployerId)
				.HasColumnName("emp_id");

			employer.Property(emp => emp.EmployerName)
				.HasColumnName("emp_employerName")
				.IsRequired();

			employer.HasMany(emp => emp.Jobs)
				.WithOne(j => j.Employer)
				.HasForeignKey(j => j.EmployerId);

			return employer;
		}
	}
}
