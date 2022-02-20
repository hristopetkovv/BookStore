using BookStore.Data.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> user)
        {
            user.ToTable("User");

            user
                .HasKey(u => u.Id);

            user
                .Property(a => a.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            user
               .Property(a => a.LastName)
               .HasMaxLength(50)
               .IsRequired();

            user
                .Property(u => u.Email)
                .HasMaxLength(100)
                .IsRequired();

            user
               .Property(u => u.Username)
               .HasMaxLength(30)
               .IsRequired();

            user
                .Property(u => u.Address)
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}
