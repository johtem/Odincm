﻿using OdinCM.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdinCM.Data.Data.Interfaces
{
    public interface IArticleRepository : IDisposable
    {

        Task<Article> GetArticleBySlug(string articleSlug);

        Task<Article> GetArticleByComment(Comment comment);

        Task<Article> GetArticleWithHistoriesBySlug(string articleSlug);

        Task<Article> GetArticleById(int articleId);

        Task<IEnumerable<Article>> GetAllArticlesPaged(int pageSize, int pageNumber);

        Task<List<Article>> GetLatestArticles(int numOfArticlesToGet);

        Task<int> GetTotalPagesOfArticles(int pageSize);

        Task<Article> CreateArticleAndHistory(Article article);

        IQueryable<Article> GetArticlesForSearchQuery(string filteredQuery);

        Task<bool> IsTopicAvailable(string articleSlug, int articleId);
    }
}
