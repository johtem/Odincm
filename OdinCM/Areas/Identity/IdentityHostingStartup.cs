using System;
using OdinCM.Areas.Identity.Data;
using OdinCM.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authorization;

[assembly: HostingStartup(typeof(OdinCM.Areas.Identity.IdentityHostingStartup))]
namespace OdinCM.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {

                services.AddDbContext<CoreOdinIdentityContext>(options =>
                options.UseSqlite(context.Configuration.GetConnectionString("CoreOdinIdentityContextConnection")));

                services.AddDefaultIdentity<CoreOdinUser>()
                .AddEntityFrameworkStores<CoreOdinIdentityContext>();

                var authBuilder = services.AddAuthentication();

                if (!string.IsNullOrEmpty(context.Configuration["Authentication:Microsoft:ApplicationId"]))
                {

                    authBuilder.AddMicrosoftAccount(microsoftOptions =>
                    {
                        microsoftOptions.ClientId = context.Configuration["Authentication:Microsoft:ApplicationId"];
                        microsoftOptions.ClientSecret = context.Configuration["Authentication:Microsoft:Password"];
                    });

                }

                if (!string.IsNullOrEmpty(context.Configuration["Authentication:Twitter:ConsumerKey"]))
                {
                    authBuilder.AddTwitter(twitterOptions =>
                    {
                        twitterOptions.ConsumerKey = context.Configuration["Authentication:Twitter:ConsumerKey"];
                        twitterOptions.ConsumerSecret = context.Configuration["Authentication:Twitter:ConsumerSecret"];
                    });

                }

                services.AddAuthorization(AuthorizationPolicy.Execute);
            });
        }
    }
}
