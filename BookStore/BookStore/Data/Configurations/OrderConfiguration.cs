using BookStore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> order)
        {
            order.ToTable("Book");

            order
                .HasKey(o => o.Id);

            order
                .HasOne(o => o.Book)
                .WithOne(b => b.Order)
                .HasForeignKey<Order>(o => o.Id);
        }
    }
}
