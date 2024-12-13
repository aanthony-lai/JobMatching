using JobMatching.Domain.Entities.Job;
using JobMatching.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace JobMatching.Infrastructure.Configurations
{
    public static class UserAggregateConfiguration
    {
        public static ModelBuilder AddUserConfigurations(this ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<User>(user =>
            {
                user.ToTable("Users")
                    .HasKey(u => u.Id);

                user.Property(u => u.Id).HasColumnName("Id");
                user.Property(u => u.Name).HasColumnName("Name").IsRequired();
                user.Property(u => u.Email).HasColumnName("Email").IsRequired();
                user.Property(u => u.UserType).HasColumnName("Type").IsRequired();

                user.Property(u => u.Created).HasColumnName("Created");
                user.Property(u => u.CreatedBy).HasColumnName("CreatedBy");
                user.Property(u => u.LastModified).HasColumnName("LastModified");
                user.Property(u => u.ModifiedBy).HasColumnName("ModifiedBy");
                user.Property(u => u.LastModified).HasColumnName("IsDeleted");
            });

            return modelBuilder;
        }
    }
}
