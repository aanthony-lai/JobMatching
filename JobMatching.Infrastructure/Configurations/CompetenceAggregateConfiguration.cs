using JobMatching.Domain.Entities.Competence;
using Microsoft.EntityFrameworkCore;

namespace JobMatching.Infrastructure.Configurations
{
    public static class CompetenceAggregateConfiguration
    {
        public static ModelBuilder AddCompetenceConfigurations(this ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Competence>(competence =>
            {
                competence.ToTable("Competences")
                    .HasKey(comp => comp.Id);

                competence.Property(comp => comp.Id).HasColumnName("Id");
                competence.Property(comp => comp.Name).HasColumnName("Name");
            });

            return modelBuilder;
        }
    }
}
