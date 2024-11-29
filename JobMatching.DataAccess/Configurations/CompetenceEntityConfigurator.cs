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
				.HasKey(c => c.CompetenceId);

				competence.Property(c => c.CompetenceId)
					.HasColumnName("Id");

				competence.Property(c => c.CompetenceName)
					.HasColumnName("Name")
					.IsRequired();

				//competence.HasMany(c => c.Jobs)
				//	.WithMany(j => j.Competences);

				competence.HasMany(c => c.Candidates)
					.WithMany(u => u.Competences);
			});

			return modelBuilder;
		}
	}
}
