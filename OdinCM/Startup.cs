using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using OdinCM.Models;
using OdinCM.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using NodaTime;
using Snickler.RSSCore;
using Snickler.RSSCore.Providers;
using Snickler.RSSCore.Extensions;
using Snickler.RSSCore.Models;
using Microsoft.AspNetCore.Http;
using OdinCM.SearchEngines;
using OdinCM.Configuration;
using Microsoft.Extensions.Options;
using OdinCM.Helpers;
using Microsoft.ApplicationInsights.Extensibility;
using OdinCM.Services;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace OdinCM
{

 

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
            services.AddRSSFeed<RSSProvider>();
            services.Configure<AppSettings>(Configuration);

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddEntityFrameworkSqlite()
                    .AddDbContext<OdinCMContext>(options =>
                            options.UseSqlite("Data Source=./wiki.db")
                    );

            //services.AddDbContext<OdinCMContext>(options =>
            //        options.UseSqlServer(Configuration.GetConnectionString("OdinCMContext")));


            // Add NodaTime clock for time-based testing. https://www.iana.org/time-zones
            services.AddSingleton<IClock>(SystemClock.Instance);

            services.AddScoped<IArticlesSearchEngine, ArticlesDbSearchEngine>();

            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddHttpContextAccessor();


            services.AddMvc()
                .AddRazorPagesOptions(options =>
                {
                    options.Conventions.AddPageRoute("/Articles/Edit", "/Articles/{Slug}/Edit");
                    options.Conventions.AddPageRoute("/Articles/Delete", "Articles/{Slug}/Delete");
                    options.Conventions.AddPageRoute("/Articles/Details", "Articles/{Slug?}");
                    options.Conventions.AddPageRoute("/Articles/Details", @"Articles/Index");
                });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // services.AddTransient<EmailNotifier>();  //To activate email notification
            services.AddSingleton<IEmailSender, EmailNotifier>();

            services.AddProgressiveWebApp();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IOptionsSnapshot<AppSettings> settings)
        {

            var initializer = new ArticleNotFoundInitializer();

            var configuration = app.ApplicationServices.GetService<TelemetryConfiguration>();
            configuration.TelemetryInitializers.Add(initializer);


            if (env.IsDevelopment())
            {

                //app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();


            app.UseRSSFeed("/articles/feed", new Snickler.RSSCore.Models.RSSFeedOptions
            {
                Title = "Odin CM Suggestion Feed",
                Copyright = DateTime.UtcNow.Year.ToString(),
                Description = "RSS Feed for Odin CM",
                Url = settings.Value.Url
            });

            var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService<OdinCMContext>();
            var identityContext = scope.ServiceProvider.GetService<CoreOdinIdentityContext>();

            app.UseStatusCodePagesWithReExecute("/HttpErrors/{0}");

            app.UseMvc();

            SeedData.Initialize(context);
            CoreOdinIdentityContext.SeedData(identityContext);
        }
    }
}
