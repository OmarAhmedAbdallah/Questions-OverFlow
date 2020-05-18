using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using App.Web.Infrastructure;
using App.Web.Data;
using App.Services;
using App.Services.Implementation;
using AutoMapper;
using App.Web.Controllers;
using System;
using App.Data.Models;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.OpenApi.Models;
using App.Controllers.Options;
using Core.Interfaces;
using Infrastructure.UnitOfWork;

//in this project from nuget install AutoMapper.Extensions.Microsoft.Dependency
namespace App.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<ApplicationDbContext>
                (options => options.UseSqlServer(Configuration.GetConnectionString("DevConnection")));

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });
            //services.AddControllersWithViews();
            services.AddRazorPages();

            //for Turn on runtime compilation ***
            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            services.AddTransient<IUsersDetailsService, UsersDetailsService>();

            services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));

            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo { Title = "QuestionsOverFlow API" });
            });

        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.useExceptionHandling(env);


            var swaggerOptions = new SwaggerOptions();
            var swaggerOption = new SwaggerOption();

            Configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggerOptions);
            app.UseSwagger(options =>
                {
                    options.RouteTemplate = swaggerOptions.RouteTemplate;
                }
            );

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "QuestionsOverFlow API");
            });

            app.UseHttpsRedirection();

            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseStaticFiles();
            
            app.UseSession();

            app.UseRouting();

            app.useEndPoints();


            //app.SeedData();

        }
    }
}
