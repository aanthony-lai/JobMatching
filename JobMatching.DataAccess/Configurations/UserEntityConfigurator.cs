using JobMatching.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobMatching.DataAccess.Configurations
{
	public static class UserEntityConfigurator
	{
		public static ModelBuilder AddUserConfiguration(this ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>(user =>
			{
				user.ToTable("Users")
					.HasKey(u => u.Id);

				user.Property(u => u.Id)
					.HasColumnName("Id");

				user.Property(u => u.Email)
					.HasColumnName("Email")
					.IsRequired();

				user.Property(u => u.IsEmployer)
					.HasColumnName("IsEmployer")
					.IsRequired();
			});

			return modelBuilder;
		}
	}
}
