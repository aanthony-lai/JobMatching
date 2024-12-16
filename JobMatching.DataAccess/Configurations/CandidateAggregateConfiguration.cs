using JobMatching.Domain.Entities.Candidate;
using Microsoft.EntityFrameworkCore;

namespace JobMatching.Infrastructure.Configurations
{
    public static class CandidateAggregateConfiguration
    {
        public static ModelBuilder AddCandidateConfigurations(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidate>(candidate =>
            {
                candidate.ToTable("Candidates")
                    .HasKey(c => c.Id);

                candidate.Property(c => c.Id)
                    .HasColumnName("Id");

                candidate.OwnsOne(c => c.Name, builder =>
                {
                    builder.Property(name => name.FirstName)
                        .HasColumnName("FirstName")
                        .IsRequired();
                    builder.Property(name => name.LastName)
                        .HasColumnName("LastName")
                        .IsRequired();
                });

                candidate.HasMany(c => c.Applications);
                candidate.HasMany(c => c.CandidateLanguages);
                candidate.HasMany(c => c.CandidateCompetences);

                candidate.Property(c => c.Created).HasColumnName("Created");
                candidate.Property(c => c.CreatedBy).HasColumnName("CreatedBy");
                candidate.Property(c => c.LastModified).HasColumnName("LastModified");
                candidate.Property(c => c.ModifiedBy).HasColumnName("ModifiedBy");
                candidate.Property(c => c.LastModified).HasColumnName("IsDeleted");
            });

            modelBuilder.Entity<JobApplication>(jobApplication =>
            {
                jobApplication.ToTable("Applications")
                    .HasKey(a => a.Id);

                jobApplication.Property(a => a.Id).HasColumnName("Id").IsRequired();
                jobApplication.Property(a => a.CandidateId).HasColumnName("CandidateId").IsRequired();
                jobApplication.Property(a => a.JobId).HasColumnName("JobId").IsRequired();
                jobApplication.Property(a => a.Status).HasColumnName("Status").IsRequired();
                jobApplication.Property(a => a.ApplicationDate).HasColumnName("ApplicationDate").IsRequired();

                jobApplication.Property(a => a.Created).HasColumnName("Created");
                jobApplication.Property(a => a.CreatedBy).HasColumnName("CreatedBy");
                jobApplication.Property(a => a.LastModified).HasColumnName("LastModified");
                jobApplication.Property(a => a.ModifiedBy).HasColumnName("ModifiedBy"); ;
                jobApplication.Property(a => a.LastModified).HasColumnName("IsDeleted");
            });

            modelBuilder.Entity<CandidateCompetence>(candidateCompetence =>
            {
                candidateCompetence.ToTable("CandidateCompetences")
                    .HasKey(comp => new { comp.CandidateId, comp.CompetenceId });

                candidateCompetence.Property(c => c.CandidateId).HasColumnName("CandidateId").IsRequired();
                candidateCompetence.Property(c => c.CompetenceId).HasColumnName("CompetenceId").IsRequired();
                candidateCompetence.Property(c => c.CompetenceLevel).HasColumnName("CompetenceLevel");
            });

            modelBuilder.Entity<CandidateLanguage>(candidateLanguage =>
            {
                candidateLanguage.ToTable("CandidateLanguages")
                    .HasKey(lang => new { lang.CandidateId, lang.LanguageId });

                candidateLanguage.Property(lang => lang.CandidateId).HasColumnName("CandidateId").IsRequired();
                candidateLanguage.Property(lang => lang.LanguageId).HasColumnName("LanguageId").IsRequired();
                candidateLanguage.Property(lang => lang.ProficiencyLevel).HasColumnName("ProficiencyLevel");
            });

            return modelBuilder;
        }
    }
}
