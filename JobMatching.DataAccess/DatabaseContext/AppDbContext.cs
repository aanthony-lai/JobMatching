using JobMatching.DataAccess.Configurations;
using JobMatching.DataAccess.Configurations.JunctionTables;
using JobMatching.Domain.Entities;
using JobMatching.Domain.Entities.JunctionEntities;
using Microsoft.EntityFrameworkCore;

namespace JobMatching.DataAccess.Context
{
	public class AppDbContext : DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<Candidate> Candidates { get; set; }
		public DbSet<Employer> Employers { get; set; }
		public DbSet<Job> Jobs { get; set; }
		public DbSet<JobApplication> JobApplications { get; set; }
		public DbSet<Competence> Competences { get; set; }
		public DbSet<CandidateLanguage> CandidateLanguages { get; set; }
		public DbSet<JobCompetence> JobCompetences { get; set; }

		public AppDbContext(DbContextOptions<AppDbContext> options)
			: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.AddUserConfiguration();
			modelBuilder.AddCandidateConfiguration();
			modelBuilder.AddEmployerConfiguration();
			modelBuilder.AddJobConfiguration();
			modelBuilder.AddJobApplicationConfiguration();
			modelBuilder.AddCompetenceConfiguration();
			modelBuilder.AddLanguageConfiguration();
			modelBuilder.AddJunctionTablesConfiguration();
		}
	}
}
