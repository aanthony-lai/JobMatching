using JobMatching.DataAccess.Configurations;
using JobMatching.DataAccess.Configurations.JunctionTables;
using JobMatching.Domain.Entities;
using JobMatching.Domain.Entities.JunctionTables;
using Microsoft.EntityFrameworkCore;

namespace JobMatching.DataAccess.Context
{
	public class AppDbContext: DbContext
	{
		public DbSet<Candidate> Candidates { get; set; }
		public DbSet<Employer> Employers { get; set; }
		public DbSet<Job> Jobs { get; set; }
		public DbSet<JobApplication> Applications { get; set; }
		public DbSet<Competence> Competences { get; set; }

		public AppDbContext(DbContextOptions<AppDbContext> options)
			: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Ignore<User>();
			modelBuilder.Entity<Candidate>().AddCandidateConfiguration();
			modelBuilder.Entity<Employer>().AddEmployerConfiguration();
			modelBuilder.Entity<Job>().AddJobConfiguration();
			modelBuilder.Entity<JobApplication>().AddApplicationConfiguration();
			modelBuilder.Entity<Competence>().AddCompetenceConfiguration();
			modelBuilder.AddJunctionTablesConfiguration();
		}
	}
}
