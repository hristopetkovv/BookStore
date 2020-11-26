﻿using BookStore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Data.Configurations
{
    public class UserBookConfiguration : IEntityTypeConfiguration<UserBook>
    {
        public void Configure(EntityTypeBuilder<UserBook> userBook)
        {
            userBook.ToTable("UserBook");

            userBook.HasKey(ub => new { ub.BookId, ub.UserId });

            userBook
                .Property(ub => ub.Pieces)
                .IsRequired();

            userBook
                .HasOne(b => b.Book)
                .WithMany(u => u.Users)
                .HasForeignKey(b => b.BookId);

            userBook
                .HasOne(u => u.User)
                .WithMany(b => b.Books)
                .HasForeignKey(u => u.UserId);
        }
    }
}
