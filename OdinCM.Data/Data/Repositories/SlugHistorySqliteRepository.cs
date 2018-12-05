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
        public SlugHistorySqliteRepository(IOdinCMContext context)
        {
            Context = context;
        }


        public IOdinCMContext Context { get; }


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
    }
}
