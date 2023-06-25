using System;
using Elevate.Api.Domain.Repositories;
using Elevate.Api.Infrastructure;
using Elevate.Api.Infrastructure.Integrations;
using Elevate.Api.Infrastructure.Integrations.Models;
using Elevate.Api.Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Elevate.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMemoryCache();
            services.AddControllers();
            services.AddCors();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Human api integration", Version = "v1" });
            });


            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

            services.AddDbContext<ApplicationDbContext>(options =>
                      options.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase")));

            services.AddScoped<IUserLoginRepo, UserLoginRepo>();
            services.AddScoped<IUserRegistrationRepo, UserRegistrationRepo>();

            services.AddOptions();

            var section = Configuration.GetSection("HumanApiSettings");
            services.Configure<HumanApiSettings>(section);

            services.AddHttpClient<IHumanApi, HumanApi>(client =>
            {
                client.BaseAddress = new Uri(Configuration["HumanApiSettings:BaseUrl"]);
                client.DefaultRequestHeaders.Add("ContentType", "Application/json");
            });

        }



        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }
            app.UseRouting();
            app.UseCors(builder => builder
                                .AllowAnyOrigin()
                                .AllowAnyHeader()
                                .AllowAnyMethod());
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = string.Empty;
            });
            app.UseEndpoints(endpoints => {

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

        }

    }
}
