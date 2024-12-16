using JobMatching.Domain.Entities.Employer;
using Microsoft.EntityFrameworkCore;

namespace JobMatching.Infrastructure.Configurations
{
    public static class EmployerAggregateConfiguration
    {
        public static ModelBuilder AddEmployerConfigurations(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employer>(employer =>
            {
                employer.ToTable("Employers")
                .HasKey(emp => emp.Id);

                employer.HasMany(emp => emp.EmployerJobs);

                employer.Property(emp => emp.Id).HasColumnName("Id").IsRequired();
                employer.Property(emp => emp.Name).HasColumnName("Name").IsRequired();
                employer.Property(c => c.Created).HasColumnName("Created");
                employer.Property(c => c.CreatedBy).HasColumnName("CreatedBy");
                employer.Property(c => c.LastModified).HasColumnName("LastModified");
                employer.Property(c => c.ModifiedBy).HasColumnName("ModifiedBy");
                employer.Property(c => c.LastModified).HasColumnName("IsDeleted");
            });

            modelBuilder.Entity<EmployerJob>(job =>
            {
                job.ToTable("EmployerJobs")
                    .HasKey(j => new { j.EmployerId, j.JobId });

                job.Property(j => j.EmployerId).HasColumnName("EmployerId").IsRequired();
                job.Property(j => j.JobId).HasColumnName("JobId").IsRequired();
            });

            return modelBuilder;
        }
    }
}
