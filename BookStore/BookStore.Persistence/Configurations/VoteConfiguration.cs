using BookStore.Data.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Persistence.Configurations
{
    public class VoteConfiguration : IEntityTypeConfiguration<Vote>
    {
        public void Configure(EntityTypeBuilder<Vote> vote)
        {
            vote.ToTable("Vote");

            vote.HasKey(v => v.Id);

            vote
                .HasOne(v => v.Book)
                .WithMany(b => b.Votes)
                .HasForeignKey(v => v.BookId);
        }
    }
}
