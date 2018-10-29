using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NodaTime;
using OdinCM.Models;

namespace OdinCM.Pages.Articles
{
    public class CreateModel : PageModel
    {
        private readonly OdinCM.Models.OdinCMContext _context;
        private readonly IClock _clock;

        public CreateModel(OdinCM.Models.OdinCMContext context, IClock clock)
        {
            _context = context;
            _clock = clock;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Article Article { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            // Checks if Topic is unique
            if (_context.Articles.Any(a => a.Topic == Article.Topic))
            {
                // Needs to be Model.
                ModelState.AddModelError($"{nameof(Article)}.{nameof(Article.Topic)}", $"The topic '{Article.Topic}' already exists. Please choose another name");
                return Page();
            }

            Article.Published = _clock.GetCurrentInstant();

            _context.Articles.Add(Article);
            await _context.SaveChangesAsync();

            return Redirect($"/Article/{Article.Topic}");
        }
    }
}