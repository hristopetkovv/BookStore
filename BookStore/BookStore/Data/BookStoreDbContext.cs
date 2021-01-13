using BookStore.Data.Common;
using BookStore.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace BookStore.Data
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options)
          : base(options)
        {

        }

        public DbSet<Book> Book { get; set; }

        public DbSet<Author> Author { get; set; }

        public DbSet<BookAuthor> BookAuthor { get; set; }

        public DbSet<Comment> Comment { get; set; }

        public DbSet<User> User { get; set; }

        public DbSet<UserBook> UserBook { get; set; }

        public DbSet<Genre> Genre { get; set; }

        public DbSet<Order> Order { get; set; }

        public DbSet<Vote> Vote { get; set; }
      
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            this.HandleWhen();
            return base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            this.HandleWhen();
            return base.SaveChanges();
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
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (var entry in changedEntries)
            {
                if(entry.Entity is IEntity entity)
                {
                    switch(entry.State)
                    {
                        case EntityState.Added:
                            entity.CreatedOn = DateTime.UtcNow;
                            break;
                        case EntityState.Modified:
                            entity.UpdatedOn = DateTime.UtcNow;
                            break;
                    }
                }

                if (entry.Entity is IDeletableEntity deletableEntity && entry.State == EntityState.Modified)
                {
                    deletableEntity.DeletedOn = DateTime.UtcNow;
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
