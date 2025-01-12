using JobMatching.Infrastructure.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobMatching.Infrastructure.Configurations
{
    public static class JobConfiguration
    {
        public static ModelBuilder AddJobConfigurations(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobEntity>(job =>
            {
                job.ToTable("Jobs").HasKey(j => j.Id);

                job.Property(j => j.Id)
                    .HasColumnName("Id");

                job.Property(j => j.Title)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("Title");

                job.Property(j => j.Description)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .HasColumnName("Description");

                job.Property(j => j.MaxSalary)
                    .IsRequired()
                    .HasColumnName("MaxSalary");

                job.Property(j => j.MinSalary)
                    .IsRequired()
                    .HasColumnName("MinSalary");

                job.Property(j => j.EmployerId)
                    .IsRequired()
                    .HasColumnName("Employer");

                job.Property(j => j.Created)
                    .IsRequired()
                    .HasColumnName("Created");

                job.Property(j => j.CreatedBy)
                    .HasMaxLength(256)
                    .HasColumnName("CreatedBy");

                job.Property(j => j.LastModified)
                    .IsRequired()
                    .HasColumnName("LastModified");

                job.Property(j => j.ModifiedBy)
                    .HasMaxLength(256)
                    .HasColumnName("ModifiedBy");

                job.Property(j => j.IsDeleted)
                    .HasDefaultValue(false)
                    .HasColumnName("IsDeleted");

                job.HasOne(j => j.Employer)
                    .WithMany(e => e.Jobs)
                    .HasForeignKey(j => j.EmployerId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);

                job.HasMany(j => j.Competences)
                    .WithOne(c => c.Job)
                    .HasForeignKey(c => c.JobId)
                    .OnDelete(DeleteBehavior.Cascade);

                job.HasMany(j => j.Applications)
                    .WithOne(ja => ja.Job)
                    .HasForeignKey(ja => ja.JobId)
                    .OnDelete(DeleteBehavior.Cascade); ;
            });

            modelBuilder.Entity<JobCompetence>(jobCompetence =>
            {
                jobCompetence.ToTable("JobCompetences").HasKey(jc => new { jc.JobId, jc.CompetenceId });

                jobCompetence.Property(jc => jc.IsCritical)
                    .HasDefaultValue(false);

                jobCompetence.HasOne(jc => jc.Job)
                    .WithMany(j => j.Competences)
                    .HasForeignKey(jc => jc.JobId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);

                jobCompetence.HasOne(jc => jc.Competence)
                    .WithMany()
                    .HasForeignKey(jc => jc.CompetenceId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);
            });

            return modelBuilder;
        }
    }
}
