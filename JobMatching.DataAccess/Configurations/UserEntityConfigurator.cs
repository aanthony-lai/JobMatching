using JobMatching.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobMatching.DataAccess.Configurations
{
	public static class UserEntityConfigurator
	{
		public static EntityTypeBuilder<User> AddUserConfiguration(this EntityTypeBuilder<User> userBuilder)
		{
			var user = userBuilder;

			user.ToTable("usr_users")
				.HasKey(u => u.UserId);

			user.Property(u => u.UserId)
				.HasColumnName("usr_id");

			user.OwnsOne(u => u.UserName, nameBuilder =>
			{
				nameBuilder.Property(fn => fn.FirstName)
					.HasColumnName("usr_firstName")
					.IsRequired();
				nameBuilder.Property(ln => ln.LastName)
					.HasColumnName("usr_lastName")
					.IsRequired();
			});

			user.HasMany(u => u.Competences)
				.WithMany(c => c.Users)
				.UsingEntity(uc => uc.ToTable("uc_userCompetences"));

			user.HasMany(u => u.Applications)
				.WithOne(ua => ua.User)
				.HasForeignKey(a => a.UserId);
			
			return user;
		}
	}
}
