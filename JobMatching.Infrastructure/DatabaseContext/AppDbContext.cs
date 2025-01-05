using JobMatching.Domain.Entities.Candidate;
using JobMatching.Domain.Entities.Competence;
using JobMatching.Domain.Entities.Employer;
using JobMatching.Domain.Entities.Job;
using JobMatching.Domain.Entities.Language;
using JobMatching.Infrastructure.Authentication;
using JobMatching.Infrastructure.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JobMatching.Infrastructure.Context
{
    public sealed class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Competence> Competences { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Language> Languages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.AddCandidateConfigurations();
            modelBuilder.AddCompetenceConfigurations();
            modelBuilder.AddJobConfigurations();
            modelBuilder.AddLanguageConfigurations();
            modelBuilder.AddEmployerConfigurations();
        }
    }
}
