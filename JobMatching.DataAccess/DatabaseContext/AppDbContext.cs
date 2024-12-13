using JobMatching.Domain.Entities.Candidate;
using JobMatching.Domain.Entities.Competence;
using JobMatching.Domain.Entities.Employer;
using JobMatching.Domain.Entities.Job;
using JobMatching.Domain.Entities.Language;
using JobMatching.Domain.Entities.Users;
using JobMatching.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace JobMatching.DataAccess.Context
{
	public class AppDbContext : DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<Candidate> Candidates { get; set; }
		public DbSet<Employer> Employers { get; set; }
		public DbSet<Competence> Competences { get; set; }
		public DbSet<Job> Jobs { get; set; }
		public DbSet<Language> Languages { get; set; }

		public AppDbContext(DbContextOptions<AppDbContext> options)
			: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.AddCandidateConfigurations();
			modelBuilder.AddCompetenceConfigurations();
			modelBuilder.AddJobConfigurations();
		}
	}
}
