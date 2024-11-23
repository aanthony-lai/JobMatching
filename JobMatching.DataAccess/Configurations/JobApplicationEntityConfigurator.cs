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

			jobApplication.ToTable("japp_jobApplications")
				.HasKey(a => a.JobApplicationId);

			jobApplication.Property(a => a.JobApplicationId)
				.HasColumnName("japp_id");

			jobApplication.HasOne(a => a.User)
				.WithMany(u => u.Applications)
				.HasForeignKey(a => a.UserId);

			jobApplication.HasOne(a => a.Job)
				.WithMany(j => j.Applications)
				.HasForeignKey(a => a.JobId);

			jobApplication.Property(a => a.ApplicationDate)
				.HasColumnName("japp_applicationDate");

			jobApplication.Property(a => a.ApplicationStatus)
				.HasColumnName("japp_Status");

			return jobApplication;
		}
	}
}
