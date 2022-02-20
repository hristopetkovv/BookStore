using BookStore.Data.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Persistence.Configurations
{
    public class KeywordsConfiguration : IEntityTypeConfiguration<BookKeyWords>
    {
        public void Configure(EntityTypeBuilder<BookKeyWords> keyword)
        {
            keyword.ToTable("BookKeyword");

            keyword
                .HasKey(c => c.Id);

            keyword
                .HasOne(c => c.Book)
                .WithMany(b => b.BookKeyWords)
                .HasForeignKey(c => c.BookId);
        }
    }
}
