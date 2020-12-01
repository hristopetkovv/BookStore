using BookStore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> order)
        {
            order.ToTable("Order");

            order
                .HasKey(o => o.Id);

            order
                .Property(o => o.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
