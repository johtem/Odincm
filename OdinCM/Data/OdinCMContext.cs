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
            modelBuilder.Entity<Article>()
                .HasIndex(b => b.Slug).IsUnique();

            modelBuilder.Entity<Article>().HasData(new[] {
                new Article
                {
                    Id = 1,
                    Topic = "HomePage",
                    Slug = "home-page",
                    Content = "This is the default home page. Please change me!",
                    Published = NodaTime.SystemClock.Instance.GetCurrentInstant(),
                    AuthorId = Guid.NewGuid()
                }
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
                    }
            });
        }

        public DbSet<OdinCM.Models.Customer> Customer { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }



    }
}
