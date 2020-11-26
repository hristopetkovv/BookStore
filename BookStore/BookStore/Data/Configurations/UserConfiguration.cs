﻿using BookStore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> user)
        {
            user.ToTable("User");

            user
                .HasKey(u => u.Id);

            user
                .Property(a => a.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            user
               .Property(a => a.LastName)
               .HasMaxLength(50)
               .IsRequired();

            user
                .Property(u => u.Email)
                .HasMaxLength(100)
                .IsRequired();

            user
                .Property(u => u.TelephoneNumber)
                .HasMaxLength(20);

            user
                .Property(u => u.Username)
                .HasMaxLength(30)
                .IsRequired();

            user
                .Property(u => u.Password)
                .HasMaxLength(40)
                .IsRequired();

            user
                .Property(u => u.Address)
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}
