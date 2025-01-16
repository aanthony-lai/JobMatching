using JobMatching.Infrastructure.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobMatching.Infrastructure.Configurations
{
    public static class CandidateConfiguration
    {
        public static ModelBuilder AddCandidateConfigurations(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CandidateEntity>(candidate =>
            {
                candidate.ToTable("Candidates")
                    .HasKey(c => c.Id);

                candidate.Property(c => c.Id)
                    .HasColumnName("Id");

                candidate.Property(c => c.FirstName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("FirstName");

                candidate.Property(c => c.LastName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("LastName");

                candidate.Property(c => c.Created)
                    .IsRequired()
                    .HasColumnName("Created");

                candidate.Property(c => c.CreatedBy)
                    .HasMaxLength(256)
                    .HasColumnName("CreatedBy");

                candidate.Property(c => c.LastModified)
                    .IsRequired()
                    .HasColumnName("LastModified");

                candidate.Property(c => c.ModifiedBy)
                    .HasMaxLength(256)
                    .HasColumnName("ModifiedBy");

                candidate.Property(c => c.IsDeleted).
                    HasColumnName("IsDeleted");

                candidate.HasOne(c => c.User)
                    .WithMany()
                    .HasForeignKey(c => c.UserId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);

                candidate.HasMany(c => c.JobApplications)
                    .WithOne(j => j.Candidate)
                    .HasForeignKey(j => j.CandidateId)
                    .OnDelete(DeleteBehavior.Cascade);

                candidate.HasMany(c => c.Languages)
                    .WithOne(l => l.Candidate)
                    .HasForeignKey(l => l.CandidateId)
                    .OnDelete(DeleteBehavior.Cascade);

                candidate.HasMany(c => c.Competences)
                    .WithOne(cc => cc.Candidate)
                    .HasForeignKey(cc => cc.CandidateId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<CandidateCompetence>(candidateCompetence =>
            {
                candidateCompetence.ToTable("CandidateCompetences")
                    .HasKey(cc => new { cc.CandidateId, cc.CompetenceId });

                candidateCompetence.Property(cc => cc.CandidateId)
                    .HasColumnName("CandidateId");

                candidateCompetence.Property(cc => cc.CompetenceId)
                    .HasColumnName("CompetenceId");

                candidateCompetence.HasOne(cc => cc.Candidate)
                    .WithMany(c => c.Competences)
                    .HasForeignKey(cc => cc.CandidateId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);

                candidateCompetence.HasOne(cc => cc.Competence)
                    .WithMany()
                    .HasForeignKey(cc => cc.CompetenceId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<CandidateLanguage>(candidateLanguage =>
            {
                candidateLanguage.ToTable("CandidateLanguages")
                    .HasKey(cl => new { cl.CandidateId, cl.LanguageId });

                candidateLanguage.Property(cl => cl.CandidateId)
                    .HasColumnName("CandidateId");

                candidateLanguage.Property(cl => cl.LanguageId)
                    .HasColumnName("LanguageId");

                candidateLanguage.Property(cl => cl.ProficiencyLevel)
                    .HasColumnName("ProficiencyLevel");

                candidateLanguage.HasOne(cl => cl.Candidate)
                    .WithMany(c => c.Languages)
                    .HasForeignKey(cl => cl.CandidateId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);

                candidateLanguage.HasOne(cl => cl.Language)
                    .WithMany()
                    .HasForeignKey(cl => cl.LanguageId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);
            });

            return modelBuilder;
        }
    }
}
