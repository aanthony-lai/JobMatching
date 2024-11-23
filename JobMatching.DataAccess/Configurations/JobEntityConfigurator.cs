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

			job.ToTable("job_jobs")
				.HasKey(j => j.JobId);

			job.Property(j => j.JobId)
				.HasColumnName("job_id");

			job.Property(j => j.JobTitle)
				.HasColumnName("job_title")
				.IsRequired();

			job.OwnsOne(j => j.JobSalaryRange, salaryBuilder =>
			{
				salaryBuilder.Property(s => s.SalaryRangeTop)
					.HasColumnName("job_salaryTop");
				salaryBuilder.Property(s => s.SalaryRangeBottom)
					.HasColumnName("job_salaryBottom");
			});

			job.HasOne(j => j.Employer)
				.WithMany(emp => emp.Jobs)
				.HasForeignKey(j => j.EmployerId);

			job.HasMany(j => j.Competences)
				.WithMany(c => c.Jobs)
				.UsingEntity(jc => jc.ToTable("JOBCOMP_JOBCOMPETENCES"));

			job.HasMany(j => j.Applications)
				.WithOne(a => a.Job)
				.HasForeignKey(a => a.JobId);

			return job;
		}
	}
}
