using BookStore.Data.Common.Interfaces;
using BookStore.Data.Data.Models;
using BookStore.Services.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BookStore.Persistence
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        private readonly IUserContext userContext;

        public AppDbContext(
			IUserContext userContext,
			DbContextOptions<AppDbContext> options)
          : base(options)
        {
            this.userContext = userContext;
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

        public DbSet<BookKeyWords> BookKeyWords { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			foreach (var entity in modelBuilder.Model.GetEntityTypes())
			{
				// Configure name mappings
				entity.SetTableName(entity.ClrType.Name.ToLower());

				if (typeof(IEntity).IsAssignableFrom(entity.ClrType))
				{
					modelBuilder.Entity(entity.ClrType)
						.HasKey(nameof(IEntity.Id));
				}

				if (typeof(IConcurrency).IsAssignableFrom(entity.ClrType))
				{
					modelBuilder.Entity(entity.ClrType)
						.Property(nameof(IConcurrency.Version))
						.IsConcurrencyToken()
						.HasDefaultValue(0);
				}

				entity.GetProperties()
					.ToList()
					.ForEach(e => e.SetColumnName(e.Name.ToLower()));

				entity.GetForeignKeys()
					.Where(e => !e.IsOwnership && e.DeleteBehavior == DeleteBehavior.Cascade)
					.ToList()
					.ForEach(e => e.DeleteBehavior = DeleteBehavior.Restrict);
			}

			modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
		}

		public Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
		{
			return Database.BeginTransactionAsync(cancellationToken);
		}

		public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
		{
			foreach (var entry in ChangeTracker.Entries())
			{
				if (typeof(IAuditable).IsAssignableFrom(entry.Entity.GetType()) && entry.State == EntityState.Added)
				{
					var entity = entry.Entity as IAuditable;
					entity.CreateDate = DateTime.Now;
					entity.CreatorUserId = this.userContext.UserId;
				}

				if (typeof(IConcurrency).IsAssignableFrom(entry.Entity.GetType()) && entry.State == EntityState.Modified)
				{
					var entity = entry.Entity as IConcurrency;
					entity.Version++;
				}
			}

			return base.SaveChangesAsync(cancellationToken);
		}
	}
}
