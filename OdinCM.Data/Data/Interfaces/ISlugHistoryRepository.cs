using OdinCM.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OdinCM.Data.Data.Interfaces
{
    public interface ISlugHistoryRepository : IDisposable
    {
        Task<SlugHistory> GetSlugHistoryWithArticle(string slug);

        Task AddToHistory(string oldSlug, Article article);
    }
}
