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

        public DbSet<OdinCM.Models.Movie> Movie { get; set; }

        public DbSet<OdinCM.Models.Customer> Customer { get; set; }
        public DbSet<Article> Articles { get; set; }
    }
}
