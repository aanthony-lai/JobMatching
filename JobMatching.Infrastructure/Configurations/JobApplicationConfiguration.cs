using JobMatching.Infrastructure.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobMatching.Infrastructure.Configurations
{
    public static class JobApplicationConfiguration
    {
        public static ModelBuilder AddJobApplicationConfigurations(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobApplicationEntity>(jobApplication =>
            {
                jobApplication.ToTable("JobApplications").HasKey(j => j.Id);

                jobApplication.Property(j => j.Id)
                    .HasColumnName("Id");

                jobApplication.Property(j => j.JobId)
                    .IsRequired()
                    .HasColumnName("JobId");

                jobApplication.Property(j => j.CandidateId)
                    .IsRequired()
                    .HasColumnName("CandidateId");

                jobApplication.Property(j => j.Status)
                    .IsRequired()
                    .HasColumnName("Status");

                jobApplication.Property(j => j.Created)
                    .IsRequired()
                    .HasColumnName("Created");

                jobApplication.Property(j => j.CreatedBy)
                    .HasMaxLength(256)
                    .HasColumnName("CreatedBy");

                jobApplication.Property(j => j.LastModified)
                    .IsRequired()
                    .HasColumnName("LastModified");

                jobApplication.Property(j => j.ModifiedBy)
                    .HasMaxLength(256)
                    .HasColumnName("ModifiedBy");

                jobApplication.Property(j => j.IsDeleted)
                    .HasDefaultValue(false)
                    .HasColumnName("IsDeleted");

                jobApplication.HasOne(j => j.Job)
                    .WithMany()
                    .HasForeignKey(j => j.JobId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);

                jobApplication.HasOne(j => j.Candidate)
                    .WithMany(c => c.JobApplications)
                    .HasForeignKey(j => j.CandidateId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);
            });

            return modelBuilder;
        }
    }
}
