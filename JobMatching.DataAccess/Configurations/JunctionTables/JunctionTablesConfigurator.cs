using JobMatching.Domain.Entities.JunctionEntities;
using JobMatching.Domain.Entities.JunctionTables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
			});

			modelBuilder.Entity<CandidateCompetence>(candidateCompetences =>
			{
				candidateCompetences.ToTable("Canidate_Competences")
					.HasKey(cc => new { cc.CandidateId, cc.CompetenceId });

				candidateCompetences.Property(cc => cc.CandidateId)
					.HasColumnName("CandidateId");

				candidateCompetences.Property(cc => cc.CompetenceId)
					.HasColumnName("CompetenceId");
			});

			return modelBuilder;
		}
	}
}
