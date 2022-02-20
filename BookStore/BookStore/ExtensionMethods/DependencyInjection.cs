using BookStore.Data.Data;
using BookStore.Services.Services;
using BookStore.Services.Services.Helpers;
using BookStore.Services.Services.Token;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.ExtensionMethods
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDatabase<TDbContext, TDbContextImplementation>(this IServiceCollection services, string connectionString)
            where TDbContext : class
            where TDbContextImplementation : DbContext, TDbContext
        {
            services
                .AddDbContext<BookStoreDbContext>(options => options.UseNpgsql(connectionString));

            services
                .AddScoped<TDbContext>(provider => provider.GetRequiredService<TDbContextImplementation>());

            return services;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            return services
                .AddTransient<IAccountService, AccountService>()
                .AddTransient<IBookService, BookService>()
                .AddTransient<IAuthorService, AuthorService>()
                .AddTransient<ICartService, CartService>()
                .AddTransient<IOrderService, OrderService>()
                .AddTransient<IAdminService, AdminService>()
                .AddTransient<IUserService, UserService>()
                .AddTransient<ITokenService, TokenService>()
                .AddTransient<IVotesService, VotesService>()
                .AddScoped<UserContext>();
        }
    }
}
