using JobMatching.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobMatching.DataAccess.Configurations
{
	public static class JobEntityConfigurator
	{
		public static ModelBuilder AddJobConfiguration(this ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Job>(job =>
			{
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

				job.HasMany(j => j.JobCompetences)
					.WithOne(comp => comp.Job)
					.HasForeignKey(comp => comp.JobId);

				job.HasMany(j => j.Applicants)
					.WithOne(a => a.Job)
					.HasForeignKey(a => a.JobId);
			});

			return modelBuilder;
		}
	}
}