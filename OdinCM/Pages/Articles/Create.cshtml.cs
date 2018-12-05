using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NodaTime;
using OdinCM.Data.Models;
using OdinCM.Helpers;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using OdinCM.Data;
using OdinCM.Data.Data.Interfaces;

namespace OdinCM.Pages.Articles
{
    public class CreateModel : PageModel
    {
        private readonly IArticleRepository _articleRepo;
        private readonly IClock _clock;
        public ILogger Logger { get; private set; }

        public CreateModel(IArticleRepository articleRepo, IClock clock, ILoggerFactory loggerFactory)
        {
            _articleRepo = articleRepo;
            _clock = clock;
            this.Logger = loggerFactory.CreateLogger("CreatePage");
        }

        public async Task<IActionResult> OnGetAsync(string slug)
        {
            if (string.IsNullOrEmpty(slug))
            {
                return Page();
            }

            if (await _articleRepo.GetArticleBySlug(slug) != null)
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
            if (string.IsNullOrWhiteSpace(slug))
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
            

            if (await _articleRepo.IsTopicAvailable(slug, 0))
            {
                ModelState.AddModelError("Article.Topic", "This Title already exists.");
                return Page();
            }

            Article.Published = _clock.GetCurrentInstant();

            Article = await _articleRepo.CreateArticleAndHistory(Article);

            var articlesToCreateFromLinks = (await ArticleHelpers.GetArticlesToCreate(_articleRepo, Article, createSlug: true))
                .ToList();

            if (articlesToCreateFromLinks.Count > 0)
            {
                return RedirectToPage("CreateArticleFromLink", new { id = slug });
            }


            return Redirect($"/Articles/{Article.Slug}");
        }

    }
}