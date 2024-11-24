using JobMatching.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobMatching.DataAccess.Configurations
{
	public static class CandidateEntityConfigurator
	{
		public static EntityTypeBuilder<Candidate> AddUserConfiguration(this EntityTypeBuilder<Candidate> candidateBuilder)
		{
			var candidate = candidateBuilder;

			candidate.ToTable("cand_candidates")
				.HasKey(u => u.CandidateId);

			candidate.Property(u => u.CandidateId)
				.HasColumnName("cand_id");

			candidate.OwnsOne(u => u.Name, nameBuilder =>
			{
				nameBuilder.Property(fn => fn.FirstName)
					.HasColumnName("cand_firstName")
					.IsRequired();
				nameBuilder.Property(ln => ln.LastName)
					.HasColumnName("cand_lastName")
					.IsRequired();
			});

			candidate.HasMany(u => u.Competences)
				.WithMany(c => c.Users)
				.UsingEntity(uc => uc.ToTable("candcom_candidateCompetences"));
			
			return candidate;
		}
	}
}
