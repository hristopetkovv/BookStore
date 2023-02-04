using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BookStore.ExtensionMethods;
using Microsoft.AspNetCore.Hosting;
using BookStore.Services.Common.Configurations;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc;
using BookStore.Services.ExtensionMethods;
using BookStore.Persistence;
using BookStore.Services.Common.Interfaces;
using BookStore.Persistence.Extensions;
using Microsoft.Extensions.Hosting;
using BookStore.Infrastructure.Middlewares;

namespace BookStore
{
    public class Startup
    {
        private readonly IWebHostEnvironment environment;

        public Startup(IWebHostEnvironment environment)
        {
            this.environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var configuration = services.ConfigureApplicationConfiguration(environment);

            services
                .AddHttpContextAccessor()
                .AddControllers(options =>
                {
                    options.OutputFormatters.Add(new HttpNoContentOutputFormatter());
                    options.Filters.Add(new ProducesAttribute("application/json"));
                })
                .AddJson();

            services
                .AddPersistence<IAppDbContext, AppDbContext>(configuration.GetSection("ConnectionStrings:DefaultConnection").Value, environment.IsDevelopment())
                .AddPersistence<IAppLogContext, AppLogContext>(configuration.GetSection("ConnectionStrings:LogConnectionString").Value, environment.IsDevelopment())
                .AddApplication();

            var authConfig = configuration.GetSection("AuthConfiguration").Get<AuthConfiguration>();
            services.ConfigureJwtAuthService(authConfig.SecretKey, authConfig.Issuer, authConfig.Audience);

            services.ConfigureAuthorization();

            services.AddDistributedMemoryCache();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            app.UseMiddleware<RedirectionMiddleware>();
            app.UseMiddleware<RequestLoggingMiddleware>();

            app.UseRouting();

            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = context => {
                    if (context.File.Name == "index.html")
                    {
                        context.Context.Response.Headers.Add("Cache-Control", "no-cache, no-store");
                        context.Context.Response.Headers.Add("Expires", "-1");
                    }
                }
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints
                           .MapControllers()
                           .RequireAuthorization());
        }
    }
}
