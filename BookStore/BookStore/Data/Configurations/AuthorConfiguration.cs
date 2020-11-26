using BookStore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Data.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> author)
        {
            author.ToTable("Author");

            author
                .HasKey(a => a.Id);

            author
                .Property(a => a.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            author
               .Property(a => a.LastName)
               .HasMaxLength(50)
               .IsRequired();
        }
    }
}
