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

			competence.ToTable("com_competences")
				.HasKey(c => c.CompetenceId);

			competence.Property(c => c.CompetenceId)
				.HasColumnName("com_id");

			competence.Property(c => c.CompetenceName)
				.HasColumnName("com_competenceName");

			competence.HasMany(c => c.Jobs)
				.WithMany(j => j.Competences);

			competence.HasMany(c => c.Users)
				.WithMany(u => u.Competences);

			return competence;
		}
	}
}
