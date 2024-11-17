using JobMatching.Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace JobMatching.DataAccess.Context
{
	public class AppDbContext: DbContext
	{
		public DbSet<User> Users { get; set; }
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

			modelBuilder.Entity<User>().OwnsOne(u => u.UserName);
			modelBuilder.Entity<Job>().OwnsOne(j => j.JobSalaryRange);


		}
	}
}
