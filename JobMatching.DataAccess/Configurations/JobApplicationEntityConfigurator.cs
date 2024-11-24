using JobMatching.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobMatching.DataAccess.Configurations
{
	public static class JobApplicationEntityConfigurator
	{
		public static EntityTypeBuilder<JobApplication> AddApplicationConfiguration(this EntityTypeBuilder<JobApplication> jobApplicationBuilder)
		{
			var jobApplication = jobApplicationBuilder;

			jobApplication.ToTable("ja_jobApplications")
				.HasKey(a => a.JobApplicationId);

			jobApplication.Property(a => a.JobApplicationId)
				.HasColumnName("ja_id");

			jobApplication.HasOne(a => a.Candidate)
				.WithMany()
				.HasForeignKey(a => a.CandidateId);

			jobApplication.HasOne(a => a.Job)
				.WithMany()
				.HasForeignKey(a => a.JobId);

			jobApplication.Property(a => a.ApplicationDate)
				.HasColumnName("ja_applicationDate");

			jobApplication.Property(a => a.ApplicationStatus)
				.HasColumnName("ja_status");

			return jobApplication;
		}
	}
}
