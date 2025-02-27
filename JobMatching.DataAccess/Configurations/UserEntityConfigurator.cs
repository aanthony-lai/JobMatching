﻿using JobMatching.Domain.Entities;
using JobMatching.Domain.Types;
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

				user.OwnsOne(u => u.Name, nameBuilder =>
				{
					nameBuilder.Property(n => n.UserName)
						.HasColumnName("Name")
						.IsRequired();
				});

				user.OwnsOne(u => u.Email, emailBuilder =>
				{
					emailBuilder.Property(e => e.Address)
						.HasColumnName("Email")
						.IsRequired();
				});

				user.Property(u => u.UserType)
					.HasColumnName("UserType")
					.HasConversion(
						ut => ut.ToString(),
						ut => (UserType)Enum.Parse(typeof(UserType), ut));

				user.OwnsOne(u => u.MetaData, metaDataBuilder =>
				{
					metaDataBuilder.Property(md => md.CreatedAt)
						.HasColumnName("CreatedAt")
						.IsRequired();
					metaDataBuilder.Property(md => md.UpdatedAt)
						.HasColumnName("UpdatedAt")
						.IsRequired();
					metaDataBuilder.Property(md => md.IsDeleted)
						.HasColumnName("IsDeleted")
						.IsRequired();
				});
			});

			return modelBuilder;
		}
	}
}
