using BookStore.Data.Common;
using BookStore.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;

namespace BookStore.Data
{
    public class BookStoreDbContext : DbContext
    {
        public DbSet<Book> Book { get; set; }

        public DbSet<Author> Author { get; set; }

        public DbSet<BookAuthor> BookAuthor { get; set; }

        public DbSet<Comment> Comment { get; set; }

        public DbSet<User> User { get; set; }

        public DbSet<UserBook> UserBook { get; set; }

        public DbSet<Genre> Genre { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("host=localhost;database=BookStore;Username=postgres;Password=1qaz2wsx");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes().ToList())
            {
                entityType.GetProperties()
                    .ToList()
                    .ForEach(e => e.SetColumnName(e.Name.ToLower()));

                entityType
                    .GetForeignKeys()
                    .Where(e => e.IsOwnership && e.DeleteBehavior == DeleteBehavior.Cascade)
                    .ToList()
                    .ForEach(e => e.DeleteBehavior = DeleteBehavior.Restrict);

                if (entityType.ClrType is IDeletableEntity)
                {
                    var method = SetIsDeletedQueryFilterMethod.MakeGenericMethod(entityType.ClrType);
                    method.Invoke(null, new object[] { modelBuilder });
                }
            }

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookStoreDbContext).Assembly);
        }

        private void HandleWhen()
        {
            var changedEntries = this.ChangeTracker
                .Entries()
                .Where(e =>
                    e.Entity is IEntity &&
                    (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in changedEntries)
            {
                IEntity entity = (IEntity)entry.Entity;

                IDeletableEntity deletableEntity = (IDeletableEntity)entry.Entity;

                if (entry.State == EntityState.Added && entity.CreatedOn == default)
                {
                    entity.CreatedOn = DateTime.UtcNow;
                }
                else
                {
                    if (deletableEntity.IsDeleted)
                    {
                        deletableEntity.DeletedOn = DateTime.UtcNow;
                    }

                    entity.UpdatedOn = DateTime.UtcNow;
                }
            }
        }

        private static readonly MethodInfo SetIsDeletedQueryFilterMethod =
                typeof(BookStoreDbContext).GetMethod(nameof(SetIsDeletedQueryFilter), BindingFlags.NonPublic | BindingFlags.Static);

        private static void SetIsDeletedQueryFilter<T>(ModelBuilder builder)
            where T : class, IDeletableEntity
        {
            builder.Entity<T>().HasQueryFilter(e => !e.IsDeleted);
        }
    }
}
