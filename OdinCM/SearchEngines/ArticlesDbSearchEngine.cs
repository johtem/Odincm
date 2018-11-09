﻿using Microsoft.EntityFrameworkCore;
using OdinCM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdinCM.SearchEngines
{
    public class ArticlesDbSearchEngine : IArticlesSearchEngine
    {
        private readonly OdinCMContext _context;

        public ArticlesDbSearchEngine(OdinCMContext context)
        {
            _context = context;
        }

        public async Task<SearchResult<Article>> SearchAsync(string query, int pageNumber, int resultsPerPage)
        {
            var filteredQuery = query.Trim();
            var offset = (pageNumber - 1) * resultsPerPage;

            var dbQuery = _context
                .Articles
                .AsNoTracking()
                .Where(article =>
                    article.Topic.ToUpper().Contains(filteredQuery.ToUpper()) ||
                    article.Content.ToUpper().Contains(filteredQuery.ToUpper())
                );

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