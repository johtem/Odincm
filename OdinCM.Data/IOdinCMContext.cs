using Microsoft.EntityFrameworkCore;
using OdinCM.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OdinCM.Data
{
    public interface IOdinCMContext : IDisposable
    {
        DbSet<Article> Articles { get; set; }
        DbSet<Comment> Comments { get; set; }
        DbSet<SlugHistory> SlugHistories { get; set; }

        DbSet<ArticleHistory> ArticleHistories { get; set; }

        DbSet<Customer> Customer { get; set; }


        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));

    }
}
