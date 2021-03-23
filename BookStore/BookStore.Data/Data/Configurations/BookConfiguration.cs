using BookStore.Data.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Data.Data.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> book)
        {
            book.ToTable("Book");

            book
                .HasKey(b => b.Id);

            book
                .Property(b => b.Title)
                .HasMaxLength(100)
                .IsRequired();

            book
                .Property(b => b.Description)
                .HasMaxLength(1000)
                .IsRequired();

            book
                .Property(b => b.Price)
                .IsRequired();

            book
                .Property(b => b.PublishHouse)
                .HasMaxLength(100)
                .IsRequired();

            book
                .Property(b => b.IsAvailable)
                .IsRequired();

            book
                .Property(b => b.PublishedOn)
                .HasColumnType("date");
        }
    }
}
