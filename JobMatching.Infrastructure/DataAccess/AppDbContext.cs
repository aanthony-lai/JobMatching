using JobMatching.Infrastructure.Configurations;
using JobMatching.Infrastructure.DataAccess.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JobMatching.Infrastructure.DataAccess
{
    public sealed class AppDbContext : IdentityDbContext<UserEntity>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<CandidateEntity> Candidates { get; set; }
        public DbSet<EmployerEntity> Employers { get; set; }
        public DbSet<CompetenceEntity> Competences { get; set; }
        public DbSet<JobEntity> Jobs { get; set; }
        public DbSet<LanguageEntity> Languages { get; set; }
        public DbSet<JobApplicationEntity> JobApplications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.AddCandidateConfigurations();
            modelBuilder.AddCompetenceConfigurations();
            modelBuilder.AddJobConfigurations();
            modelBuilder.AddLanguageConfigurations();
            modelBuilder.AddEmployerConfigurations();
            modelBuilder.AddJobApplicationConfigurations();
            modelBuilder.AddUserConfiguration();
        }
    }
}
