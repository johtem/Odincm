using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OdinCM.Models;
using NodaTime;
using OdinCM.Helpers;
using Microsoft.AspNetCore.Authorization;
using SendGrid;
using SendGrid.Helpers.Mail;
using OdinCM.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Configuration;
using OdinCM.Services;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace OdinCM.Pages.Articles
{
    
    public class DetailsModel : PageModel
    {
        private readonly OdinCM.Models.OdinCMContext _context;
        private readonly IClock _clock;
        private readonly UserManager<CoreOdinUser> _userManager;
        private readonly INotificationService _notificationService;

        public IConfiguration Configuration { get; }
        public IEmailSender Notifier { get; }


        public DetailsModel(OdinCM.Models.OdinCMContext context, UserManager<CoreOdinUser> userManager,
            IConfiguration config, IClock clock, INotificationService notificationService)
        {
            _context = context;
            _clock = clock;
            _userManager = userManager;            
            _notificationService = notificationService;
            this.Configuration = config;
        }

        public Article Article { get; set; }

        [ViewDataAttribute]
        public string Slug { get; set; }

        public async Task<IActionResult> OnGetAsync(string slug)
        {
            slug = slug ?? "home-page";


            Article = await _context.Articles.FirstOrDefaultAsync(m => m.Slug == slug.ToLower());
            Article = await _context.Articles.Include(x => x.Comments).SingleOrDefaultAsync(m => m.Slug == slug.ToLower());

            if (Article == null)
            {
                Slug = slug;
                var historical = await _context.SlugHistories.Include(h => h.Article)
                    .OrderByDescending(h => h.Added)
                    .FirstOrDefaultAsync(h => h.OldSlug == slug.ToLowerInvariant());

                if (historical != null)
                {
                    return new RedirectResult($"~/{historical.Article.Slug}");
                }
                else
                {
                    return new ArticleNotFoundResult(slug);
                }

            }

            if (Request.Cookies[Article.Topic] == null)
            {
                Article.ViewCount++;
                Response.Cookies.Append(Article.Topic, "foo", new Microsoft.AspNetCore.Http.CookieOptions
                {
                    Expires = DateTime.UtcNow.AddMinutes(5)
                });

                await _context.SaveChangesAsync();

            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Models.Comment comment)
        {
            TryValidateModel(comment);
            Article = await _context.Articles.Include(x => x.Comments).SingleOrDefaultAsync(m => m.Id == comment.IdArticle);

            if (Article == null)
                return new ArticleNotFoundResult();

            if (!ModelState.IsValid)
                return Page();

            comment.Article = this.Article;

            comment.Submitted = _clock.GetCurrentInstant();

            _context.Comments.Add(comment);
            var author = await _userManager.FindByIdAsync(this.Article.AuthorId.ToString());
            await _context.SaveChangesAsync();
            await _notificationService.NotifyAuthorNewComment(author, Article, comment);

            
            return Redirect($"/Articles/{Article.Slug}");
        }
    }
}
