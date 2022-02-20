using BookStore.Data.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Persistence.Configurations
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
