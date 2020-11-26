using BookStore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Data.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> comment)
        {
            comment.ToTable("Comment");

            comment
                .HasKey(c => c.Id);

            comment
                .Property(c => c.Text)
                .HasMaxLength(200)
                .IsRequired();

            comment
                .Property(c => c.Username)
                .IsRequired();

            comment
                .HasOne(c => c.Book)
                .WithMany(b => b.Comments)
                .HasForeignKey(c => c.BookId);
        }
    }
}
