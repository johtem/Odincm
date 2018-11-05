
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdinCM.Models
{
    public static class SeedData
    {
        public static void Initialize(OdinCMContext context)
        {
            // Makes sure that the database is created.
            context.Database.EnsureCreated();

            //Load an initial Article home page
            if (!context.Articles.Any(a => a.Topic == "HomePage"))
            {
                var homePageArticle = new Article
                {
                    Topic = "HomePage",
                    Slug = "home-page",
                    Content = "This is the default home page. Please change me!",
                    Published = SystemClock.Instance.GetCurrentInstant()
                };
                context.Articles.Add(homePageArticle);
                context.SaveChanges();
            }


            if (!context.Customer.Any())
            {
                context.Customer.AddRange(
                    new Customer
                    {
                        CustomerName = "Skf",
                        CreatedAt = SystemClock.Instance.GetCurrentInstant(),
                        UpdatedAt = SystemClock.Instance.GetCurrentInstant()
                    },
                    new Customer
                    {
                        CustomerName = "ABB",
                        CreatedAt = SystemClock.Instance.GetCurrentInstant(),
                        UpdatedAt = SystemClock.Instance.GetCurrentInstant()
                    });

                context.SaveChanges();

            }
        }
    }
}
