
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

                       
        }
    }
}
