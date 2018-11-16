using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using OdinCM.Configuration;
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

        private readonly OdinCMContext _context;
        private readonly Uri baseURL;

        
        public RSSProvider(OdinCMContext context, IOptionsSnapshot<AppSettings> settings)
        {
            _context = context;
            baseURL = settings.Value.Url;
        }


        public async Task<IList<RSSItem>> RetrieveSyndicationItems()
        {
            var articles = await _context.Articles.OrderByDescending(a => a.Published).Take(10).ToListAsync();
            return articles.Select(rssItem =>
            {
                var absoluteURL = new Uri(baseURL, $"/Articles/{rssItem.Slug}");

                var wikiItem = new RSSItem
                {
                    Content = rssItem.Content, 
                    PermaLink = absoluteURL,
                    LinkUri = absoluteURL,
                    PublishDate = rssItem.Published.ToDateTimeUtc(),
                    LastUpdated = rssItem.Published.ToDateTimeUtc(),
                    Title = rssItem.Topic
                };

                wikiItem.Authors.Add("Johan Tempelman"); // TODO: Gram from user who saved record
                return wikiItem;
            }).ToList();
        }
    }
}
