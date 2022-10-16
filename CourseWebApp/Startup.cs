using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using CourseWebApp.Models;
using CourseWebApp.Data;
using CourseWebApp.Services;


namespace CourseWebApp;
    public class Startup
    {
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews();

        services.AddDbContext<CourseWebAppContext>(options =>
                    options.UseMySql("server=localhost;userid=root;password=root;database=coursewebappdb",
                    ServerVersion.Parse("8.0.27-mysql")));


        services.AddScoped<SeedingService>();
        services.AddScoped<SellerService>();
        services.AddScoped<DepartmentService>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, SeedingService seedingService)
    {
        var enUS = new CultureInfo("en-US");

        var localizationOption = new RequestLocalizationOptions
        {
            DefaultRequestCulture = new RequestCulture("en-US"),
            SupportedCultures = new List<CultureInfo> { enUS },
            SupportedUICultures = new List<CultureInfo> { enUS }
        };

        app.UseRequestLocalization(localizationOption);

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            seedingService.Seed();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Sellers}/{action=Index}/{id?}");
        });
    }
}
