using JobMatching.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobMatching.DataAccess.Configurations
{
	public static class CandidateEntityConfigurator
	{
		public static ModelBuilder AddCandidateConfiguration(this ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Candidate>(candidate =>
			{
				candidate.ToTable("Candidates")
					.HasKey(c => c.Id);

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
					nameBuilder.Ignore(n => n.UserName);
				});

				candidate.HasMany(c => c.Competences)
					.WithMany(comp => comp.Candidates)
					.UsingEntity<Dictionary<string, object>>(
						"Candidate_Competences",
						cc => cc.HasOne<Competence>().WithMany().HasForeignKey("CompetenceId"),
						cc => cc.HasOne<Candidate>().WithMany().HasForeignKey("CandidateId"));

				candidate.HasMany(c => c.JobApplications)
					.WithOne(ja => ja.Candidate)
					.HasForeignKey(ja => ja.CandidateId);

				candidate.HasMany(c => c.Languages)
					.WithOne(l => l.Candidate)
					.HasForeignKey(l => l.CandidateId);

				candidate.Property(c => c.HasDriversLicence)
					.HasColumnName("HasDriversLicense")
					.IsRequired(false);

				candidate.HasOne(c => c.User)
					.WithOne()
					.HasForeignKey<Candidate>(c => c.UserId);

				candidate.OwnsOne(c => c.MetaData, metaDataBuilder =>
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