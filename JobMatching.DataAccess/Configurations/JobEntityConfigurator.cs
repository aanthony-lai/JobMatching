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

			job.ToTable("job_Jobs")
				.HasKey(j => j.JobId);

			job.Property(j => j.JobId)
				.HasColumnName("job_Id");

			job.Property(j => j.JobTitle)
				.HasColumnName("job_Title")
				.IsRequired();

			job.OwnsOne(j => j.SalaryRange, salaryBuilder =>
			{
				salaryBuilder.Property(s => s.SalaryRangeTop)
					.HasColumnName("job_SalaryTop");
				salaryBuilder.Property(s => s.SalaryRangeBottom)
					.HasColumnName("job_SalaryBottom");
			});

			job.HasOne(j => j.Employer)
				.WithMany(emp => emp.Jobs)
				.HasForeignKey(j => j.EmployerId);

			job.HasMany(j => j.Competences)
				.WithMany(c => c.Jobs)
				.UsingEntity(jc => jc.ToTable("jcom_JobCompetences"));

			return job;
		}
	}
}
