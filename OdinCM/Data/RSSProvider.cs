using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OdinCM.Models;
using Snickler.RSSCore.Models;
using Snickler.RSSCore.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdinCM.Data
{
    public class RSSProvider : IRSSProvider
    {

        private OdinCMContext _context;

        private IConfiguration Configuration;

        public RSSProvider(OdinCMContext context, IConfiguration config)
        {
            _context = context;
            Configuration = config;
        }


        public async Task<IList<RSSItem>> RetrieveSyndicationItems()
        {
            var articles = await _context.Articles.OrderByDescending(a => a.Published).Take(10).ToListAsync();
            return articles.Select(rssItem =>
            {
                var wikiItem = new RSSItem
                {
                    Content = rssItem.Content, //TODO: May need to truncate long article
                    PermaLink = new Uri($"{Configuration["Url"]}/Articles/{rssItem.Slug}"),
                    LinkUri = new Uri($"{Configuration["Url"]}/Articles/{rssItem.Slug}"),
                    PublishDate = rssItem.PublishedDateTime,
                    LastUpdated = rssItem.PublishedDateTime,
                    Title = rssItem.Topic
                };

                wikiItem.Authors.Add("Johan Tempelman"); // TODO: Gram from user who saved record
                return wikiItem;
            }).ToList();
        }
    }
}
