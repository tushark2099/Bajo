using Bajo.Data;
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
        public static void AddIdentityAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 8;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

            //services.AddAuthentication()
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
    }
}
