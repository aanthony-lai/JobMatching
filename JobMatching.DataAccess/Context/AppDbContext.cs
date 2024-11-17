using JobMatching.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobMatching.DataAccess.Context
{
	public class AppDbContext: DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<Employer> Employers { get; set; }
		public DbSet<Job> Jobs { get; set; }
		public DbSet<Application> Applications { get; set; }
		public DbSet<Competence> Competences { get; set; }

		public AppDbContext(DbContextOptions<AppDbContext> options)
			: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			var users = modelBuilder.Entity<User>();
			

		}
	}
}
