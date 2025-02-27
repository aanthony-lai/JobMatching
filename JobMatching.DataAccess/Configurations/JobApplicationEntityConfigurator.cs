﻿using JobMatching.Domain.Entities;
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
				jobApplication
					.ToTable("JobApplications")
					.HasKey(a => a.Id);

				jobApplication
					.Property(a => a.Id)
					.HasColumnName("Id");

				jobApplication
					.HasOne(a => a.Candidate)
					.WithMany(c => c.JobApplications)
					.HasForeignKey(a => a.CandidateId)
					.OnDelete(DeleteBehavior.Cascade);

				jobApplication
					.HasOne(a => a.Job)
					.WithMany(j => j.Applicants)
					.HasForeignKey(a => a.JobId)
					.OnDelete(DeleteBehavior.NoAction);

				jobApplication.Property(a => a.ApplicationDate)
					.HasColumnName("ApplicationDate")
					.IsRequired();

				jobApplication.Property(a => a.ApplicationStatus)
					.HasColumnName("Status")
					.IsRequired();

				jobApplication.OwnsOne(a => a.MetaData, metaDataBuilder =>
				{
					metaDataBuilder.Property(md => md.CreatedAt)
						.HasColumnName("CreatedAt")
						.IsRequired();
					metaDataBuilder.Property(md => md.UpdatedAt)
						.HasColumnName("UpdatedAt")
						.IsRequired();
					metaDataBuilder.Property(md => md.IsDeleted)
						.HasColumnName("IsDeleted")
						.IsRequired();
				});
			});

			return modelBuilder;
		}
	}
}
