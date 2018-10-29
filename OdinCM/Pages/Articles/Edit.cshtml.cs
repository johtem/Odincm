using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NodaTime;
using OdinCM.Models;

namespace OdinCM.Pages.Articles
{
    public class EditModel : PageModel
    {
        private readonly OdinCM.Models.OdinCMContext _context;

        private readonly IClock _clock;

        public EditModel(OdinCM.Models.OdinCMContext context, IClock clock)
        {
            _context = context;
            _clock = clock;
        }

        [BindProperty]
        public Article Article { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Article = await _context.Articles.FirstOrDefaultAsync(m => m.Topic == id);

            if (Article == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Article.Published = _clock.GetCurrentInstant();

            _context.Attach(Article).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticleExists(Article.Topic))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("Details");
        }

        private bool ArticleExists(string id)
        {
            return _context.Articles.Any(e => e.Topic == id);
        }
    }
}
