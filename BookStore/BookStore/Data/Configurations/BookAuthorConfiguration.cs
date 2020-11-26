using BookStore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Data.Configurations
{
    public class BookAuthorConfiguration : IEntityTypeConfiguration<BookAuthor>
    {
        public void Configure(EntityTypeBuilder<BookAuthor> bookAuthor)
        {
            bookAuthor.ToTable("BookAuthor");

            bookAuthor
                .HasKey(e => new { e.AuthorId, e.BookId });

            bookAuthor
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId);

            bookAuthor
                .HasOne(a => a.Book)
                .WithMany(b => b.Authors)
                .HasForeignKey(a => a.BookId);
        }
    }
}
