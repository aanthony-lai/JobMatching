using JobMatching.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobMatching.DataAccess.Configurations
{
	public static class CandidateEntityConfigurator
	{
		public static EntityTypeBuilder<Candidate> AddCandidateConfiguration(this EntityTypeBuilder<Candidate> candidateBuilder)
		{
			var candidate = candidateBuilder;

			candidate.ToTable("Candidates");
				//.HasBaseType<User>();
			candidate.HasKey(c => c.CandidateId);

			candidate.Property(c => c.CandidateId)
				.HasColumnName("Id");

			candidate.OwnsOne(c => c.FullName, nameBuilder =>
			{
				nameBuilder.Property(fn => fn.FirstName)
					.HasColumnName("FirstName")
					.IsRequired();
				nameBuilder.Property(ln => ln.LastName)
					.HasColumnName("LastName")
					.IsRequired();
			});

			candidate.HasMany(c => c.Competences)
				.WithMany(comp => comp.Candidates);

			return candidate;
		}
	}
}