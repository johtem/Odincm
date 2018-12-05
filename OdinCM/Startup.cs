using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using OdinCM.Configuration;
using OdinCM.Models;
using OdinCM.Data;
using OdinCM.Data.Data.Interfaces;
using OdinCM.Data.Data.Repositories;
using OdinCM.Helpers;
using OdinCM.SearchEngines;
using OdinCM.Services;
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
using Microsoft.Extensions.Options;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc;

namespace OdinCM
{



    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment hostingEnviroment)
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
                    .AddDbContext<IOdinCMContext, OdinCMContext>(options =>
                            options.UseSqlite(Configuration.GetConnectionString("OdinData"))
                            .EnableSensitiveDataLogging(true)  
                    );

            // DB Repos
            services.AddTransient<IArticleRepository, ArticleSqliteRepository>();
            services.AddTransient<ICommentRepository, CommentSqliteRepository>();
            services.AddTransient<ISlugHistoryRepository, SlugHistorySqliteRepository>();
            services.AddTransient<ICustomerRepository, CustomerSqliteRepository>();


            //services.AddDbContext<OdinCMContext>(options =>
            //        options.UseSqlServer(Configuration.GetConnectionString("OdinCMContext")));


            // Add NodaTime clock for time-based testing. https://www.iana.org/time-zones
            services.AddSingleton<IClock>(SystemClock.Instance);

            services.AddScoped<IArticlesSearchEngine, ArticlesDbSearchEngine>();
            services.AddScoped<ITemplateProvider, TemplateProvider>();
            services.AddScoped<ITemplateParser, TemplateParser>();
            services.AddScoped<IEmailMessageFormatter, EmailMessageFormatter>();
            services.AddScoped<IEmailNotifier, EmailNotifier>();
            services.AddScoped<INotificationService, NotificationService>();

            services.AddScoped<IArticlesSearchEngine, ArticlesDbSearchEngine>();

            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddHttpContextAccessor();

            services.AddLocalization(options => options.ResourcesPath = "Globalization");


            services.AddMvc(options =>
            {
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                // Add support for finding localized views, based on file name suffix, e.g. Index.fr.cshtml
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                // Add support for localizing strings in data annotations (e.g. validation messages) via the
                // IStringLocalizer abstractions.
                .AddDataAnnotationsLocalization()
                .AddRazorPagesOptions(options =>
                {
                    options.Conventions.AddPageRoute("/Articles/Edit", "/Articles/{Slug}/Edit");
                    options.Conventions.AddPageRoute("/Articles/Delete", "Articles/{Slug}/Delete");
                    options.Conventions.AddPageRoute("/Articles/Details", "Articles/{Slug?}");
                    options.Conventions.AddPageRoute("/Articles/Details", @"Articles/Index");
                    options.Conventions.AddPageRoute("/Articles/Create", "Articles/{Slug?}/Create");
                    options.Conventions.AddPageRoute("/Articles/History", "Articles/{Slug?}/History");
                });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


            services.AddProgressiveWebApp();



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IOptionsSnapshot<AppSettings> settings)
        {

            var initializer = new ArticleNotFoundInitializer();

           // var configuration = app.ApplicationServices.GetService<TelemetryConfiguration>();
           // configuration.TelemetryInitializers.Add(initializer);


            if (env.IsDevelopment())
            {

                //app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // app.UseHsts();
            }

            app.UseHsts(options => options.MaxAge(days: 365).IncludeSubdomains());
            app.UseXContentTypeOptions();
            app.UseReferrerPolicy(options => options.NoReferrer());
            app.UseXXssProtection(options => options.EnabledWithBlockMode());
            app.UseXfo(options => options.Deny());


            var supportedCultures = new[]
            {
                new CultureInfo("en"),
                new CultureInfo("sv"),
                new CultureInfo("es")
            };


            // var locOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("en"),
                // Formatting numbers, dates, etc
                SupportedCultures = supportedCultures,
                // UI strings that we have localized
                SupportedUICultures = supportedCultures
            });

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
            var context = scope.ServiceProvider.GetService<IOdinCMContext>();
            var identityContext = scope.ServiceProvider.GetService<CoreOdinIdentityContext>();

            app.UseStatusCodePagesWithReExecute("/HttpErrors/{0}");

            app.UseMvc();

         //   OdinCMContext.SeedData((OdinCMContext)context);
            CoreOdinIdentityContext.SeedData(identityContext);
        }
    }
}
