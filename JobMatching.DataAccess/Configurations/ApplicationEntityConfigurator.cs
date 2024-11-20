using JobMatching.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobMatching.DataAccess.Configurations
{
	public static class ApplicationEntityConfigurator
	{
		public static EntityTypeBuilder<JobApplication> AddApplicationConfiguration(this EntityTypeBuilder<JobApplication> applicationBuilder)
		{
			var application = applicationBuilder;

			application.ToTable("app_applications")
				.HasKey(a => a.JobApplicationId);

			application.Property(a => a.JobApplicationId)
				.HasColumnName("app_id");

			application.HasOne(a => a.User)
				.WithMany(u => u.Applications)
				.HasForeignKey(a => a.UserId);

			application.HasOne(a => a.Job)
				.WithMany(j => j.Applications)
				.HasForeignKey(a => a.JobApplicationId);

			application.Property(a => a.ApplicationDate)
				.HasColumnName("app_applicationDate");

			application.Property(a => a.ApplicationStatus)
				.HasColumnName("app_applicationStatus");

			return application;
		}
	}
}
