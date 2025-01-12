using JobMatching.Domain.Entities.Employer;
using JobMatching.Infrastructure.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobMatching.Infrastructure.Configurations
{
    public static class EmployerConfiguration
    {
        public static ModelBuilder AddEmployerConfigurations(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployerEntity>(employer =>
            {
                employer.ToTable("Employers").HasKey(e => e.Id);

                employer.Property(e => e.Id)
                    .HasColumnName("Id");

                employer.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("Name");

                employer.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("UserId");

                employer.Property(e => e.Created)
                    .IsRequired()
                    .HasColumnName("Created");

                employer.Property(e => e.CreatedBy)
                    .HasMaxLength(256)
                    .HasColumnName("CreatedBy");

                employer.Property(e => e.LastModified)
                    .IsRequired()
                    .HasColumnName("LastModified");

                employer.Property(e => e.ModifiedBy)
                    .HasMaxLength(256)
                    .HasColumnName("ModifiedBy");

                employer.Property(e => e.IsDeleted)
                    .HasDefaultValue(false)
                    .HasColumnName("IsDeleted");

                employer.HasOne(e => e.User)
                    .WithMany()
                    .HasForeignKey(e => e.UserId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);

                employer.HasMany(e => e.Jobs)
                    .WithOne(j => j.Employer)
                    .HasForeignKey(j => j.EmployerId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            return modelBuilder;
        }
    }
}
