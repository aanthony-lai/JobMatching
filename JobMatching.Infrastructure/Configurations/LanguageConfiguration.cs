using JobMatching.Infrastructure.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobMatching.Infrastructure.Configurations
{
    public static class LanguageConfiguration
    {
        public static ModelBuilder AddLanguageConfigurations(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LanguageEntity>(language =>
            {
                language.ToTable("Languages").HasKey(l => l.Id);

                language.Property(l => l.Id)
                    .HasColumnName("Id");

                language.Property(l => l.Name)
                    .HasColumnName("Name");

                language.Property(l => l.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            return modelBuilder;
        }
    }
}
