using Microsoft.EntityFrameworkCore;
using OdinCM.Data;
using OdinCM.Data.Data.Interfaces;
using OdinCM.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdinCM.SearchEngines
{
    public class ArticlesDbSearchEngine : IArticlesSearchEngine
    {
        private readonly IArticleRepository _articleRepo;

        public ArticlesDbSearchEngine(IArticleRepository articleRepo)
        {
            _articleRepo = articleRepo;
        }

        public async Task<SearchResult<Article>> SearchAsync(string query, int pageNumber, int resultsPerPage)
        {
            var filteredQuery = query.Trim();
            var offset = (pageNumber - 1) * resultsPerPage;

            var dbQuery = _articleRepo.GetArticlesForSearchQuery(filteredQuery);

            var totalResults = await dbQuery.CountAsync();

            var articles = await dbQuery
                .Skip(offset)
                .Take(resultsPerPage)
                .OrderByDescending(a => a.ViewCount)
                .ToListAsync();

            return new SearchResult<Article>
            {
                Query = filteredQuery,
                Results = articles,
                CurrentPage = pageNumber,
                ResultsPerPage = resultsPerPage,
                TotalResults = totalResults
            };
        }
    }

}
