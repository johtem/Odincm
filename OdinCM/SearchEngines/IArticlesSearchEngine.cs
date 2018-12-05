using OdinCM.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdinCM.SearchEngines
{
    public interface IArticlesSearchEngine
    {
        Task<SearchResult<Article>> SearchAsync(string query, int pageNumber, int resultsPerPage);
    }
}
