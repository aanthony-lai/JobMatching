using JobMatching.Domain.Entities.Job;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace JobMatching.Infrastructure.Configurations
{
    public static class JobAggregateConfiguration
    {
        public static ModelBuilder AddJobConfigurations(this ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Job>(job =>
            {
                job.ToTable("Jobs")
                    .HasKey(j => j.Id);

                job.Property(j => j.Id).HasColumnName("Id");

                job.OwnsOne(j => j.JobTitle, builder =>
                {
                    builder.Property(t => t.Title)
                        .HasColumnName("Title")
                        .IsRequired();
                });
                job.OwnsOne(j => j.Description, builder =>
                {
                    builder.Property(d => d.Description)
                        .HasColumnName("Description")
                        .IsRequired();
                });
                job.OwnsOne(j => j.Salary, builder =>
                {
                    builder.Property(s => s.MaxSalary)
                        .HasColumnName("MaxSalary").IsRequired(false);
                    builder.Property(s => s.MinSalary)
                        .HasColumnName("MinSalary").IsRequired(false);
                });

                job.HasMany(j => j.JobCompetences);
                job.HasMany(j => j.Applicants);

                job.Property(j => j.EmployerId).HasColumnName("EmployerId");
                job.Property(j => j.Created).HasColumnName("Created");
                job.Property(j => j.CreatedBy).HasColumnName("CreatedBy");
                job.Property(j => j.LastModified).HasColumnName("LastModified");
                job.Property(j => j.ModifiedBy).HasColumnName("ModifiedBy");
                job.Property(j => j.IsDeleted).HasColumnName("IsDeleted");
            });

            modelBuilder.Entity<JobCompetence>(jobCompetence =>
            {
                jobCompetence.ToTable("JobCompetences")
                    .HasKey(c => new { c.JobId, c.CompetenceId });

                jobCompetence.Property(c => c.CompetenceName).HasColumnName("CompetenceName").IsRequired();
                jobCompetence.Property(c => c.JobId).HasColumnName("JobId").IsRequired();
                jobCompetence.Property(c => c.CompetenceId).HasColumnName("CompetenceId").IsRequired();
                jobCompetence.Property(c => c.IsCritical).HasColumnName("IsCritical").IsRequired();
            });

            modelBuilder.Entity<Applicant>(applicant =>
            {
                applicant.ToTable("Applicants")
                    .HasKey(c => new { c.JobId, c.CandidateId });

                applicant.Property(c => c.JobId).HasColumnName("JobId").IsRequired();
                applicant.Property(c => c.CandidateId).HasColumnName("CandidateId").IsRequired();
            });

            return modelBuilder;
        }
    }
}
