using JobMatching.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobMatching.DataAccess.Configurations
{
	public static class CompetenceEntityConfigurator
	{
		public static ModelBuilder AddCompetenceConfiguration(this ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Competence>(competence =>
			{
				competence.ToTable("Competences")
				.HasKey(c => c.Id);

				competence.Property(c => c.Id)
					.HasColumnName("Id");

				competence.Property(c => c.CompetenceName)
					.HasColumnName("Name")
					.IsRequired();

				competence.HasMany(c => c.Candidates)
					.WithMany(u => u.Competences);

				competence.OwnsOne(c => c.MetaData, metaDataBuilder =>
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
