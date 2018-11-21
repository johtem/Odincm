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

namespace OdinCM.Pages.Articles
{
    public class CreateModel : PageModel
    {
        private readonly OdinCMContext _context;
        private readonly IClock _clock;
        private readonly ILogger _loggerFactory;

        public CreateModel(OdinCM.Models.OdinCMContext context, IClock clock, ILoggerFactory loggerFactory)
        {
            _context = context;
            _clock = clock;
            _loggerFactory = loggerFactory.CreateLogger("CreatePage");
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Article Article { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {

            var slug = UrlHelpers.URLFriendly(Article.Topic.ToLower());
            Article.Slug = slug;
            Article.AuthorId = Guid.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier)); 

            if (!ModelState.IsValid)
            {
                return Page();
            }

               

            _loggerFactory.LogInformation($"Creating page with slug: {slug}");
            var isAvailable = !_context.Articles.Any(x => x.Slug == slug);

            if (isAvailable == false)
            {
                ModelState.AddModelError("Article.Topic", "This Title already exists.");
                return Page();
            }

            Article.Published = _clock.GetCurrentInstant();
            

            _context.Articles.Add(Article);
            await _context.SaveChangesAsync();

            return Redirect($"/Articles/{Article.Slug}");
        }

    }
}