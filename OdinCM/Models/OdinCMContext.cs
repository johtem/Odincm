using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using OdinCM.Models;
using NodaTime;

namespace OdinCM.Models
{
    public class OdinCMContext : DbContext
    {
        public OdinCMContext (DbContextOptions<OdinCMContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var homePage = new Article
            {
                Id = 1,
                Topic = "HomePage",
                Slug = "home-page",
                Content = "This is the default home page.  Please change me!",
                Published = NodaTime.SystemClock.Instance.GetCurrentInstant(),
                AuthorId = Guid.NewGuid()
            };

            var homePageHistory = ArticleHistory.FromArticle(homePage);
            homePageHistory.Id = 1;
            homePageHistory.Article = null;

            modelBuilder.Entity<Article>(entity =>
            {
                entity.HasIndex(a => a.Slug).IsUnique();
                entity.HasData(homePage);
            });

            modelBuilder.Entity<ArticleHistory>(entity =>
            {
                entity.HasData(homePageHistory);
            });

            modelBuilder.Entity<SlugHistory>(entity =>
            {
                entity.HasIndex(a => new { a.OldSlug, a.AddedDateTime });
            });


            modelBuilder.Entity<Customer>().HasData(new[]
            {
                new Customer
                    {
                        CustomerID = 1,
                        CustomerName = "Skf",
                        CreatedAt = NodaTime.SystemClock.Instance.GetCurrentInstant(),
                        UpdatedAt = NodaTime.SystemClock.Instance.GetCurrentInstant()
                    },
                    new Customer
                    {
                        CustomerID = 2,
                        CustomerName = "ABB",
                        CreatedAt = NodaTime.SystemClock.Instance.GetCurrentInstant(),
                        UpdatedAt = NodaTime.SystemClock.Instance.GetCurrentInstant()
                    },
                    new Customer
                    {
                        CustomerID = 3,
                        CustomerName = "Yara",
                        CreatedAt = NodaTime.SystemClock.Instance.GetCurrentInstant(),
                        UpdatedAt = NodaTime.SystemClock.Instance.GetCurrentInstant()
                    },
                    new Customer
                    {
                        CustomerID = 4,
                        CustomerName = "Ericsson",
                        CreatedAt = NodaTime.SystemClock.Instance.GetCurrentInstant(),
                        UpdatedAt = NodaTime.SystemClock.Instance.GetCurrentInstant()
                    }
            });
        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<SlugHistory> SlugHistories { get; set; }
        public DbSet<ArticleHistory> ArticleHistories { get; set; }

        internal static void SeedData(OdinCMContext context)
        {
            context.Database.Migrate();
        }

    }
}
