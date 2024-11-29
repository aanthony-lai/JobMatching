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

			//modelBuilder.Entity<CandidateCompetence>(candidateCompetences =>
			//{
			//	candidateCompetences.ToTable("Canidate_Competences")
			//		.HasKey(cc => new { cc.CandidateId, cc.CompetenceId });

			//	candidateCompetences.Property(cc => cc.CandidateId)
			//		.HasColumnName("CandidateId");

			//	candidateCompetences.Property(cc => cc.CompetenceId)
			//		.HasColumnName("CompetenceId");
			//});

			return modelBuilder;
		}
	}
}
