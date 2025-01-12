using JobMatching.Domain.Entities.User;
using JobMatching.Infrastructure.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobMatching.Infrastructure.Configurations
{
    public static class UserConfiguration
    {
        public static ModelBuilder AddUserConfiguration(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>(user =>
            {
                user.ToTable("Users").HasKey(u => u.Id);
                user.Property(u => u.FirstName).HasColumnName("FirstName").IsRequired(false);
                user.Property(u => u.LasName).HasColumnName("LastName").IsRequired(false);
                user.Property(u => u.EmployerName).HasColumnName("EmployerName").IsRequired(false);
                user.Property(u => u.UserName).HasColumnName("UserName").IsRequired();
                
                user.Property(u => u.UserType)
                    .HasColumnName("UserType")
                    .HasConversion(
                        ut => ut.ToString(),
                        ut => (UserType)Enum.Parse(typeof(UserType), ut))
                    .IsRequired();
                
                user.Property(u => u.Email).HasColumnName("Email").IsRequired();
                user.Property(u => u.PasswordHash).HasColumnName("PasswordHash").IsRequired();
                user.Property(u => u.SecurityStamp).HasColumnName("SecurityStamp");
                user.Property(u => u.ConcurrencyStamp).HasColumnName("ConcurrencyStamp");
                user.Property(u => u.ConcurrencyStamp).HasColumnName("ConcurrencyStamp");

                user.Ignore(u => u.EmailConfirmed);
                user.Ignore(u => u.PhoneNumber);
                user.Ignore(u => u.PhoneNumberConfirmed);
                user.Ignore(u => u.TwoFactorEnabled);
                user.Ignore(u => u.LockoutEnd);
                user.Ignore(u => u.LockoutEnabled);
                user.Ignore(u => u.AccessFailedCount);
            });

            return modelBuilder;
        }
    }
}
