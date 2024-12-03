using JobMatching.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobMatching.DataAccess.Configurations
{
	public static class LanguageEntityConfigurator
	{
		public static ModelBuilder AddLanguageConfiguration(this ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Language>(language =>
			{
				language.ToTable("Languages")
					.HasKey(lan => lan.Id);

				language.Property(lan => lan.Name)
					.HasColumnName("Language")
					.IsRequired();

				language.OwnsOne(u => u.MetaData, metaDataBuilder =>
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
