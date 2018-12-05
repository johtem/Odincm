using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NodaTime;
using OdinCM.Data;
using OdinCM.Data.Data.Interfaces;
using OdinCM.Helpers;
using OdinCM.Data.Models;

namespace OdinCM.Pages.Articles
{
    public class EditModel : PageModel
    {
        private readonly OdinCMContext _context;
        private readonly IArticleRepository _articleRepo;
        private readonly IClock _clock;

        public EditModel(IOdinCMContext context, IArticleRepository articleRepo, IClock clock)
        {
            _context = (OdinCMContext)context;
            _articleRepo = articleRepo;
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

            // Force an update on the existing Article object
            _context.Attach(Article).State = EntityState.Modified;

            Article.Published = _clock.GetCurrentInstant();
            Article.Slug = slug;
            Article.AuthorId = Guid.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
            Article.AuthorName = User.Identity.Name;

            if (!string.Equals(Article.Slug, existingArticle.Slug, StringComparison.InvariantCulture))
            {
                var historical = new SlugHistory()
                {
                    OldSlug = existingArticle.Slug,
                    Article = Article,
                    Added = _clock.GetCurrentInstant()
                };

                _context.Attach(historical).State = EntityState.Added;
            }

            AddNewArticleVersion();

            try
            {
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticleExists(Article.Id))
                {
                    return new ArticleNotFoundResult();
                }
                else
                {
                    throw;
                }
            }

           
            if (articlesToCreateFromLinks.Count > 0)
            {
                return RedirectToPage("CreateArticleFromLink", new { id = slug });
            }


            return Redirect($"/Articles/{(Article.Slug == "home-page" ? "" : Article.Slug)}");
        }

        private void AddNewArticleVersion()
        {

            _context.ArticleHistories.Add(ArticleHistory.FromArticle(Article));

        }

        private bool ArticleExists(int id)
        {
            return _context.Articles.Any(e => e.Id == id);
        }
    }
}