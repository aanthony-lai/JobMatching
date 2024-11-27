using JobMatching.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobMatching.DataAccess.Configurations
{
	public static class JobApplicationEntityConfigurator
	{
		public static ModelBuilder AddJobApplicationConfiguration(this ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<JobApplication>(jobApplication =>
			{
				jobApplication.ToTable("JobApplications")
				.HasKey(a => a.JobApplicationId);

				jobApplication.Property(a => a.JobApplicationId)
					.HasColumnName("Id");

				jobApplication.HasOne(a => a.Candidate)
					.WithMany()
					.HasForeignKey(a => a.CandidateId)
					.OnDelete(DeleteBehavior.Cascade);

				jobApplication.HasOne(a => a.Job)
					.WithMany()
					.HasForeignKey(a => a.JobId)
					.OnDelete(DeleteBehavior.NoAction);

				jobApplication.Property(a => a.ApplicationDate)
					.HasColumnName("ApplicationDate")
					.IsRequired();

				jobApplication.Property(a => a.ApplicationStatus)
					.HasColumnName("Status")
					.IsRequired();
			});

			return modelBuilder;
		}
	}
}
