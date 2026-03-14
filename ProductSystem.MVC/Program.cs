using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProductSystem.DAL;
using ProductSystem.DAL.Data.Context;
using ProductSystem.Extensions;
using System;

namespace ProductSystem.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(  options =>
             {
                options.UseSqlServer(builder.Configuration.GetConnectionString("ProductSystem"));
             });

            builder.Services.AddBusinessLogic();
            builder.Services
                .AddIdentity<ApplicationUser, IdentityRole>(options => { })
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();
 
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Account/Login";
                    options.AccessDeniedPath = "/Account/AccessDenied";
                    options.LogoutPath = "/Account/Logout";
                    options.ExpireTimeSpan = TimeSpan.FromDays(7);
                });
            builder.Services.AddAuthentication()
            .AddGoogle(options =>
            {
                options.ClientId = builder.Configuration["Authentication:Google:ClientId"];
                 options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
             });
            builder.Services.Configure<MailSettings>( builder.Configuration.GetSection("MailSettings"));

            builder.Services.AddScoped<EmailService>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Account}/{action=Login}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
