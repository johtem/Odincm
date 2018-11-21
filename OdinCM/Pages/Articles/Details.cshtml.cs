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

        public IConfiguration Configuration { get; }
        public IEmailSender Notifier { get; }

        public DetailsModel(OdinCM.Models.OdinCMContext context, IClock clock, UserManager<CoreOdinUser> userManager,
            IConfiguration config, IEmailSender notifier)
        {
            _context = context;
            _clock = clock;
            _userManager = userManager;
            this.Configuration = config;
            this.Notifier = notifier;
        }

        public Article Article { get; set; }

        public async Task<IActionResult> OnGetAsync(string slug)
        {
            slug = slug ?? "home-page";


            Article = await _context.Articles.FirstOrDefaultAsync(m => m.Slug == slug.ToLower());
            Article = await _context.Articles.Include(x => x.Comments).SingleOrDefaultAsync(m => m.Slug == slug.ToLower());

            if (Article == null)
            {
                return new ArticleNotFoundResult(slug);
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
            await _context.SaveChangesAsync();

            // TODO: Add email notification here

            var authorEmail = (await _userManager.FindByIdAsync(Article.AuthorId.ToString())).Email;

            var thisUrl = Request.GetEncodedUrl();

            await Notifier.SendEmailAsync(authorEmail, "You have a new comment!", $"Someone said something about your article at {thisUrl}");

           

            return Redirect($"/Articles/{Article.Slug}");
        }
    }
}
