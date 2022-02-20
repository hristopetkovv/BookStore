using BookStore.Services.Common.Interfaces;
using BookStore.Services.DomainValidation;
using BookStore.Services.Infrastructure.Auth;
using BookStore.Services.Logging;
using BookStore.Services.Services;
using BookStore.Services.Services.Token;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.Services.ExtensionMethods
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddTransient<IAccountService, AccountService>()
                .AddTransient<IBookService, BookService>()
                .AddTransient<IAuthorService, AuthorService>()
                .AddTransient<ICartService, CartService>()
                .AddTransient<IOrderService, OrderService>()
                .AddTransient<IAdminService, AdminService>()
                .AddTransient<IUserService, UserService>()
                .AddTransient<ITokenService, TokenService>()
                .AddTransient<IVotesService, VotesService>()
                ;

            services
                .AddScoped<ILoggingService, DbLoggingService>()
                .AddScoped<IUserContext, UserContext>()
            ;

            services
                .AddScoped<DomainValidationService>();

            return services;
        }
    }
}
