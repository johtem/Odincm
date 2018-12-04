using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OdinCM.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdinCM.Models
{
    public class CoreOdinIdentityContext : IdentityDbContext<CoreOdinUser>
    {
        public CoreOdinIdentityContext(DbContextOptions<CoreOdinIdentityContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(new[]
            {
                new IdentityRole
                {
                    Name = "Authors",
                    NormalizedName = "Authors"
                },
                new IdentityRole
            {
                Name = "Editors",
                NormalizedName = "Editors"
            },
                new IdentityRole
            {
                Name = "Administrators",
                NormalizedName = "Administrators"
                }
        });

        }

        internal static void SeedData(CoreOdinIdentityContext context)
        {
            context.Database.Migrate();

        }

    }
}
