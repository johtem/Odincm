using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OdinCM.Models;

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
        }

        public DbSet<OdinCM.Models.Customer> Customer { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }



    }
}
