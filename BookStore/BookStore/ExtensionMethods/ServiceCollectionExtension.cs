using BookStore.Data;
using BookStore.Data.Data;
using BookStore.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace BookStore.ExtensionMethods
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            return services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My Api", Version = "v1" });
            });
        }

        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddDbContext<BookStoreDbContext>(
                options => options.UseNpgsql(
                    configuration.GetConnectionString("DefaultConnection")));
        }

        public static IServiceCollection AddAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
               {
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuerSigningKey = true,
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenKey"])),
                       ValidateIssuer = false,
                       ValidateAudience = false
                   };
               });

            services.AddHttpContextAccessor();

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

        public static IServiceCollection AddAuthorizationDefault(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
         {
             options.DefaultPolicy = new AuthorizationPolicyBuilder()
                 .RequireAuthenticatedUser()
                 .Build();
         });

            return services;
        }
    }
}
