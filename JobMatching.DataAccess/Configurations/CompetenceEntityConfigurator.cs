using JobMatching.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobMatching.DataAccess.Configurations
{
	public static class CompetenceEntityConfigurator
	{
		public static EntityTypeBuilder<Competence> AddCompetenceConfiguration(this EntityTypeBuilder<Competence> competenceBuilder)
		{
			var competence = competenceBuilder;

			competence.ToTable("Competences")
				.HasKey(c => c.CompetenceId);

			competence.Property(c => c.CompetenceId)
				.HasColumnName("Id");

			competence.Property(c => c.CompetenceName)
				.HasColumnName("Name")
				.IsRequired();

			competence.HasMany(c => c.Jobs)
				.WithMany(j => j.Competences);

			competence.HasMany(c => c.Candidates)
				.WithMany(u => u.Competences);

			return competence;
		}
	}
}
