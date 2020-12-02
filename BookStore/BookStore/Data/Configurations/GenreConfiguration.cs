using BookStore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Data.Configurations
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> genre)
        {
            genre.ToTable("Genre");

            genre
                .HasKey(g => g.Id);

            genre
                .Property(g => g.Id)
                .ValueGeneratedOnAdd();

            genre
                .Property(g => g.Name)
                .HasMaxLength(50)
                .IsRequired();

            genre
                .HasOne(g => g.Book)
                .WithOne(b => b.Genre)
                .HasForeignKey<Genre>(g => g.BookId);
        }
    }
}
