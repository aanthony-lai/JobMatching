using JobMatching.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobMatching.DataAccess.Configurations
{
	public static class JobEntityConfigurator
	{
		public static EntityTypeBuilder<Job> AddJobConfiguration(this EntityTypeBuilder<Job> jobBuilder)
		{
			var job = jobBuilder;

			job.ToTable("Jobs")
				.HasKey(j => j.JobId);

			job.Property(j => j.JobId)
				.HasColumnName("Id");

			job.Property(j => j.JobTitle)
				.HasColumnName("Title")
				.IsRequired();

			job.OwnsOne(j => j.SalaryRange, salaryBuilder =>
			{
				salaryBuilder.Property(st => st.SalaryRangeTop)
					.HasColumnName("SalaryRange_Top");
				salaryBuilder.Property(sb => sb.SalaryRangeBottom)
					.HasColumnName("SalaryRange_Bottom");
			});

			job.HasOne(j => j.Employer)
				.WithMany(emp => emp.Jobs)
				.HasForeignKey(j => j.EmployerId);

			job.HasMany(j => j.Competences)
				.WithMany(comp => comp.Jobs);

			return job;
		}
	}
}