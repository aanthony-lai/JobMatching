using JobMatching.Domain.Entities.Language;
using Microsoft.EntityFrameworkCore;

namespace JobMatching.Infrastructure.Configurations
{
    public static class LanguageAggregateConfiguration
    {
        public static ModelBuilder AddLanguageConfigurations(this ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Language>(language =>
            {
                language.ToTable("Languages")
                    .HasKey(lang => lang.Id);

                language.Property(lang => lang.Id).HasColumnName("Id");
                language.Property(lang => lang.Name).HasColumnName("Name");
            }); 

            return modelBuilder;
        }
    }
}
