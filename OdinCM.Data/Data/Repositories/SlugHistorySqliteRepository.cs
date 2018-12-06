using Microsoft.EntityFrameworkCore;
using OdinCM.Data.Data.Interfaces;
using OdinCM.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdinCM.Data.Data.Repositories
{
    public class SlugHistorySqliteRepository : ISlugHistoryRepository
    {
        public SlugHistorySqliteRepository(OdinCMContext context)
        {
            Context = context;
        }


        public OdinCMContext Context { get; }


        public async Task<SlugHistory> GetSlugHistoryWithArticle(string slug)
        {
            return await Context.SlugHistories.Include(h => h.Article)
                .OrderByDescending(h => h.Added)
                .FirstOrDefaultAsync(h => h.OldSlug == slug.ToLowerInvariant());
        }


        public void Dispose()
        {
            Context.Dispose();
        }

        public Task AddToHistory(string oldSlug, Article article)
        {

            var newSlug = new SlugHistory()
            {
                OldSlug = oldSlug,
                Article = article,
                AddedDateTime = DateTime.UtcNow
            };

            Context.SlugHistories.Add(newSlug);
            return Context.SaveChangesAsync();

        }

    }
}
