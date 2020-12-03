using BookStore.Data;
using BookStore.Data.Models;
using BookStore.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

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

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            return services
                .AddTransient<IIdentityService, IdentityService>()
                .AddTransient<IBookService, BookService>()
                .AddTransient<IAuthorService, AuthorService>()
                .AddTransient<IUserService, UserService>()
                .AddTransient<IOrderService, OrderService>()
                .AddTransient<IAdminService, AdminService>();
        }
    }
}
