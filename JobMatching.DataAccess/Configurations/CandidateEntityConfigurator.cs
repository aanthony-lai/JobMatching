using JobMatching.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobMatching.DataAccess.Configurations
{
	public static class CandidateEntityConfigurator
	{
		public static ModelBuilder AddCandidateConfiguration(this ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Candidate>(candidate =>
			{
				candidate.ToTable("Candidates")
					.HasBaseType<User>();

				candidate.Property(c => c.Id)
					.HasColumnName("Id");

				candidate.OwnsOne(c => c.Name, nameBuilder =>
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

				candidate.HasMany(c => c.JobApplications)
					.WithOne(ja => ja.Candidate)
					.HasForeignKey(ja => ja.CandidateId);
			});

			return modelBuilder;
		}
	}
}