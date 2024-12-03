using JobMatching.Domain.Entities.JunctionEntities;
using Microsoft.EntityFrameworkCore;

namespace JobMatching.DataAccess.Configurations.JunctionTables
{
	public static class JunctionTablesConfigurator
	{
		public static ModelBuilder AddJunctionTablesConfiguration(this ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<JobCompetence>(jobCompetences =>
			{
				jobCompetences.ToTable("Job_Competences")
					.HasKey(jc => new { jc.JobId, jc.CompetenceId });

				jobCompetences.Property(jc => jc.JobId)
					.HasColumnName("JobId");

				jobCompetences.Property(jc => jc.CompetenceId)
					.HasColumnName("CompetenceId");

				jobCompetences.HasOne(jc => jc.Job)
					.WithMany(j => j.JobCompetences)
					.HasForeignKey(jc => jc.JobId)
					.OnDelete(DeleteBehavior.Cascade);

				jobCompetences.HasOne(jc => jc.Competence);
			});

			modelBuilder.Entity<CandidateLanguage>(candidateLanguages =>
			{
				candidateLanguages.ToTable("Candidate_Languages")
					.HasKey(cl => new { cl.CandidateId, cl.LanguageId });

				candidateLanguages.Property(cl => cl.CandidateId)
					.HasColumnName("CandidateId");

				candidateLanguages.Property(cl => cl.LanguageId)
					.HasColumnName("LanguageId");

				candidateLanguages.HasOne(cl => cl.Language);

				candidateLanguages.Property(cl => cl.ProficiencyLevel)
					.HasColumnName("ProficiencyLevel")
					.HasConversion<int>();
			});

			return modelBuilder;
		}
	}
}
