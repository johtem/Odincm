using OdinCM.Data;
using OdinCM.Data.Data.Interfaces;
using OdinCM.Data.Data.Repositories;
using OdinCM.Data.Models;
using OdinCM.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NodaTime;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OdinCM.Pages.Articles
{
    public class EditModel : PageModel
    {
        
        private readonly IArticleRepository _articleRepo;
        private readonly ISlugHistoryRepository _slugRepo;
        private readonly IClock _clock;

        public EditModel( IArticleRepository articleRepo, ISlugHistoryRepository slugHistoryRepository, IClock clock)
        {
            _articleRepo = articleRepo;
            _slugRepo = slugHistoryRepository;
            _clock = clock;
        }

        [BindProperty]
        public Article Article { get; set; }

        public async Task<IActionResult> OnGetAsync(string slug)
        {
            if (slug == null)
            {
                return NotFound();
            }

            Article = await _articleRepo.GetArticleBySlug(slug);

            if (Article == null)
            {
                return new ArticleNotFoundResult();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var existingArticle = await _articleRepo.GetArticleById(Article.Id);
            Article.ViewCount = existingArticle.ViewCount;
            Article.Version = existingArticle.Version + 1;

            //check if the slug already exists in the database.  
            var slug = UrlHelpers.URLFriendly(Article.Topic);
            if (String.IsNullOrWhiteSpace(slug))
            {
                ModelState.AddModelError("Article.Topic", "The Topic must contain at least one alphanumeric character.");
                return Page();
            }

            if (await _articleRepo.IsTopicAvailable(slug, Article.Id))
            {
                ModelState.AddModelError("Article.Topic", "This Title already exists.");
                return Page();
            }

            // Verify if there are links to new articles
            var articlesToCreateFromLinks = (await ArticleHelpers.GetArticlesToCreate(_articleRepo, Article, createSlug: true)).ToList();

            
            Article.Published = _clock.GetCurrentInstant();
            Article.Slug = slug;
            Article.AuthorId = Guid.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
            Article.AuthorName = User.Identity.Name;

            if (!string.Equals(Article.Slug, existingArticle.Slug, StringComparison.InvariantCulture))
            {
                await _slugRepo.AddToHistory(existingArticle.Slug, Article);
            }

            //AddNewArticleVersion();

            try
            {
                await _articleRepo.Update(Article);
            }
            catch (ArticleNotFoundException)
            {
                return new ArticleNotFoundResult();
            }

           
            if (articlesToCreateFromLinks.Count > 0)
            {
                return RedirectToPage("CreateArticleFromLink", new { id = slug });
            }


            return Redirect($"/Articles/{(Article.Slug == "home-page" ? "" : Article.Slug)}");
        }

       

    }
}