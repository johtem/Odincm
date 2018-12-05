using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NodaTime;
using OdinCM.Helpers;
using OdinCM.Data.Models;
using OdinCM.Data.Data.Interfaces;

namespace OdinCM.Pages.Articles
{
    [Authorize]
    public class CreateArticleFromLinkModel : PageModel
    {
        [BindProperty]
        public Article Article { get; set; }
        [BindProperty]
        public List<string> LinksToCreate { get; set; } = new List<string>();

        private readonly IArticleRepository _articleRepo;
        private readonly IClock _clock;

        public CreateArticleFromLinkModel(IArticleRepository articleRepo, IClock clock)
        {
            _articleRepo = articleRepo;
            _clock = clock;
        }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Article = await _articleRepo.GetArticleBySlug(id);

            if (Article == null)
            {
                return new ArticleNotFoundResult();
            }

            LinksToCreate = (await ArticleHelpers.GetArticlesToCreate(_articleRepo, Article)).ToList();

            if (LinksToCreate.Count == 0)
            {
                return Redirect($"/Articles/{(Article.Slug == "home-page" ? "" : Article.Slug)}");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostCreateLinksAsync(string slug)
        {
            foreach (var link in LinksToCreate)
            {
                var newArticle = new Article
                {
                    Slug = link,
                    Topic = link.ToTitleCase()
                                .RemoveHyphens(),
                    Published = _clock.GetCurrentInstant(),
                    Content = string.Empty
                };

                newArticle = await _articleRepo.CreateArticleAndHistory(newArticle);
            }

            return Redirect($"/Articles/{(slug == "home-page" ? "" : slug)}");
        }

        public IActionResult OnPostCancel(string slug)
        {
            return Redirect($"/Articles/{(slug == "home-page" ? "" : slug)}");
        }
    }
}
