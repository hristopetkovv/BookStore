using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BookStore.ExtensionMethods;

namespace BookStore
{
    public class Startup
    {
        private readonly IConfiguration configuration;
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddDatabase(this.configuration)
                .AddApplicationServices()
                //.AddCors()
                .AddAuthentication(this.configuration)
                .AddSwagger()
                .AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app
                .UseSwagger()
                .UseSwaggerUI(c =>
                    {
                        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My BookStore Api");
                        c.RoutePrefix = string.Empty;
                    })
                .UseAuthentication()
                //.UseHttpsRedirection()
                .UseRouting()
                //.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200"))
                .UseAuthorization()
                .UseEndpoints(endpoints =>
                    {
                        endpoints.MapControllers();
                    });
        }
    }
}
