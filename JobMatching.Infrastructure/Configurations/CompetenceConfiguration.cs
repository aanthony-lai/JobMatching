using JobMatching.Domain.Entities.Competence;
using JobMatching.Infrastructure.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobMatching.Infrastructure.Configurations
{
    public static class CompetenceConfiguration
    {
        public static ModelBuilder AddCompetenceConfigurations(this ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<CompetenceEntity>(competence =>
            {
                competence.ToTable("Competences").HasKey(c => c.Id);

                competence.Property(c => c.Id)
                    .HasColumnName("Id");

                competence.Property(c => c.Name)
                    .HasColumnName("Name");

                competence.Property(c => c.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            return modelBuilder;
        }
    }
}
