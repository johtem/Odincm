using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NodaTime;
using OdinCM.Models;
using OdinCM.Helpers;
using Microsoft.Extensions.Logging;
using OdinCM.Areas.Identity.Data;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace OdinCM.Pages.Articles
{
    public class CreateModel : PageModel
    {
        private readonly OdinCMContext _context;
        private readonly IClock _clock;
        public ILogger Logger { get; private set; }

        public CreateModel(OdinCMContext context, IClock clock, ILoggerFactory loggerFactory)
        {
            _context = context;
            _clock = clock;
            this.Logger = loggerFactory.CreateLogger("CreatePage");
        }

        public async Task<IActionResult> OnGetAsync(string slug)
        {
            if (string.IsNullOrEmpty(slug))
            {
                return Page();
            }

            Article article = await _context.Articles.SingleOrDefaultAsync(m => m.Slug == slug);

            if (article != null)
            {
                return Redirect($"/Articles/{slug}/Edit");
            }


            Article = new Article()
            {
                Topic = UrlHelpers.SlugToTopic(slug)
            };

            return Page();
        }



        [BindProperty]
        public Article Article { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            var slug = UrlHelpers.URLFriendly(Article.Topic);
            if (String.IsNullOrWhiteSpace(slug))
            {
                ModelState.AddModelError("Article.Topic", "The Topic must contain at least one alphanumeric character.");
                return Page();
            }
          
            Article.Slug = slug;
            Article.AuthorId = Guid.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier)); 

            if (!ModelState.IsValid)
            {
                return Page();
            }
  
            // Check if slug already exist in database
            Logger.LogWarning($"Creating page with slug: {slug}");
            var isAvailable = !_context.Articles.Any(x => x.Slug == slug);

            if (isAvailable == false)
            {
                ModelState.AddModelError("Article.Topic", "This Title already exists.");
                return Page();
            }

            Article.Published = _clock.GetCurrentInstant();
            
            _context.Articles.Add(Article);
            _context.ArticleHistories.Add(ArticleHistory.FromArticle(Article));
            await _context.SaveChangesAsync();

            var articlesToCreateFromLinks = ArticleHelpers.GetArticlesToCreate(_context, Article, createSlug: true)
                .ToList();

            if (articlesToCreateFromLinks.Count > 0)
            {
                return RedirectToPage("CreateArticleFromLink", new { id = slug });
            }


            return Redirect($"/Articles/{Article.Slug}");
        }

    }
}