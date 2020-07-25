using Bajo.Areas.Identity.Data.Models;
using Bajo.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bajo.Extensions
{
    public static class IdentityManagementSetup
    {
        public static void AddIdentityAuthentication(this IServiceCollection services)//, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 8;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                options.LoginPath = "/Identity/Account/Login";
            });

            //services.AddAuthentication().AddCookie(options =>
            //{
            //    options.LoginPath = "/Identity/Pages/Login";
            //    options.LogoutPath = "/logout";
            //});
            //.AddGoogle(googleOptions =>
            //{
            //    googleOptions.ClientId = configuration["Authentication:Google:ClientId"];
            //    googleOptions.ClientSecret = configuration["Authentication:Google:ClientSecret"];
            //})
            //.AddFacebook(facebookOptions =>
            //{
            //    facebookOptions.AppId = configuration["Authentication:Facebook:AppId"];
            //    facebookOptions.AppSecret = configuration["Authentication:Facebook:AppSecret"];
            //});
        }

        public static void AddIdentityAuthorization(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            services.AddAuthorization(options =>
            {
                options.FallbackPolicy = new AuthorizationPolicyBuilder()
                                        .RequireAuthenticatedUser()
                                        .Build();
            });
        }
    }
}
