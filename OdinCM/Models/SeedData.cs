﻿
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
                    Content = "This is the default home page. Please change me!",
                    Published = SystemClock.Instance.GetCurrentInstant()
                };
                context.Articles.Add(homePageArticle);
                context.SaveChanges();
            }
        }
    }
}
