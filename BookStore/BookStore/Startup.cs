using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BookStore.ExtensionMethods;
using Microsoft.AspNetCore.Hosting;
using BookStore.Data.Data.Common;
using BookStore.Data.Data;
using BookStore.Services.Common.Configurations;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc;

namespace BookStore
{
    public class Startup
    {
        private readonly IWebHostEnvironment environment;

        public Startup(IWebHostEnvironment environment)
        {
            this.environment = environment;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var configuration = services.ConfigureApplicationConfiguration(environment);

            services
                .AddHttpContextAccessor()
                .AddControllers(options => {
                    options.OutputFormatters.Add(new HttpNoContentOutputFormatter());
                    options.Filters.Add(new ProducesAttribute("application/json"));
                })
                .AddJson();

            services
                .AddDatabase<IAppDbContext, BookStoreDbContext>(configuration.GetSection("DbConfiguration:ConnectionString").Value)
                .AddApplicationServices();

            var authConfig = configuration.GetSection("AuthConfiguration").Get<AuthConfiguration>();
            services.ConfigureJwtAuthService(authConfig.SecretKey, authConfig.Issuer, authConfig.Audience);

            services.ConfigureAuthorization();

            services.AddDistributedMemoryCache();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app
                .UseAuthentication()
                //.UseHttpsRedirection()
                .UseRouting()
                .UseAuthorization()
                .UseEndpoints(endpoints =>
                    {
                        endpoints.MapControllers()
                            .RequireAuthorization();
                    });
        }
    }
}
