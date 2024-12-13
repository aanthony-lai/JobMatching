using JobMatching.Domain.Entities.Candidate;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

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

                candidate.Property(c => c.UserId)
                    .HasColumnName("UserId")
                    .IsRequired();

                candidate.HasOne(c => c.User);
                candidate.HasMany(c => c.Applications);
                candidate.HasMany(c => c.CandidateLanguages);
                candidate.HasMany(c => c.CandidateCompetences);

                candidate.Property(c => c.Created).HasColumnName("Created");
                candidate.Property(c => c.CreatedBy).HasColumnName("CreatedBy");
                candidate.Property(c => c.LastModified).HasColumnName("LastModified");
                candidate.Property(c => c.ModifiedBy).HasColumnName("ModifiedBy");
                candidate.Property(c => c.LastModified).HasColumnName("IsDeleted");
            });

            modelBuilder.Entity<CandidateApplication>(application =>
            {
                application.ToTable("Applications")
                    .HasKey(a => a.Id);
                
                application.Property(a => a.Id).HasColumnName("Id").IsRequired();
                application.Property(a => a.CandidateId).HasColumnName("CandidateId").IsRequired();
                application.Property(a => a.JobId).HasColumnName("JobId").IsRequired();
                application.Property(a => a.Status).HasColumnName("Status").IsRequired();
                application.Property(a => a.ApplicationDate).HasColumnName("ApplicationDate").IsRequired();

                application.Property(a => a.Created).HasColumnName("Created");
                application.Property(a => a.CreatedBy).HasColumnName("CreatedBy");
                application.Property(a => a.LastModified).HasColumnName("LastModified");
                application.Property(a => a.ModifiedBy).HasColumnName("ModifiedBy"); ;
                application.Property(a => a.LastModified).HasColumnName("IsDeleted");
            });

            modelBuilder.Entity<CandidateCompetence>(competence =>
            {
                competence.ToTable("CandidateCompetences")
                    .HasKey(comp => new { comp.CandidateId, comp.CompetenceId });

                competence.Property(c => c.CandidateId).HasColumnName("CandidateId").IsRequired();
                competence.Property(c => c.CompetenceId).HasColumnName("CompetenceId").IsRequired();
                competence.Property(c => c.CompetenceLevel).HasColumnName("CompetenceLevel");
            });

            modelBuilder.Entity<CandidateLanguage>(language =>
            {
                language.ToTable("CandidateLanguages")
                    .HasKey(lang => new { lang.CandidateId, lang.LanguageId });

                language.Property(lang => lang.CandidateId).HasColumnName("CandidateId").IsRequired();
                language.Property(lang => lang.LanguageId).HasColumnName("LanguageId").IsRequired();
                language.Property(lang => lang.ProficiencyLevel).HasColumnName("ProficiencyLevel");
            });

            return modelBuilder;
        }
    }
}
