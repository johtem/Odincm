using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OdinCM.Data.Models;
using OdinCM.Data;
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
using OdinCM.Data.Data.Interfaces;

namespace OdinCM.Pages.Articles
{
    
    public class DetailsModel : PageModel
    {
        private readonly IArticleRepository _articleRepo;
        private readonly ICommentRepository _commentRepo;
        private readonly ISlugHistoryRepository _slugHistoryRepo;
        private readonly IClock _clock;
        private readonly UserManager<CoreOdinUser> _userManager;
        private readonly INotificationService _notificationService;

        public IConfiguration Configuration { get; }
        public IEmailSender Notifier { get; }


        public DetailsModel(
            IArticleRepository articleRepo,
            ICommentRepository commentRepo,
            ISlugHistoryRepository slugHistoryRepo,
            UserManager<CoreOdinUser> userManager,
            IConfiguration config,
            IClock clock,
            INotificationService notificationService)
        {
            _articleRepo = articleRepo;
            _commentRepo = commentRepo;
            _slugHistoryRepo = slugHistoryRepo;
            _clock = clock;
            _userManager = userManager;            
            _notificationService = notificationService;
            Configuration = config;
        }

        public Article Article { get; set; }

        [ViewDataAttribute]
        public string Slug { get; set; }

        public async Task<IActionResult> OnGetAsync(string slug)
        {
            slug = slug ?? "home-page";

            Article = await _articleRepo.GetArticleBySlug(slug);              

            if (Article == null)
            {
                Slug = slug;
                var historical = await _slugHistoryRepo.GetSlugHistoryWithArticle(slug);

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

            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Comment comment)
        {
            TryValidateModel(comment);
            Article = await _articleRepo.GetArticleByComment(comment);

            if (Article == null)
                return new ArticleNotFoundResult();

            if (!ModelState.IsValid)
                return Page();

            comment.Article = Article;

            comment.Submitted = _clock.GetCurrentInstant();

           
            var author = await _userManager.FindByIdAsync(Article.AuthorId.ToString());
            await _commentRepo.CreateComment(comment);
            await _notificationService.NotifyAuthorNewComment(author, Article, comment);

            
            return Redirect($"/Articles/{Article.Slug}");
        }
    }
}
