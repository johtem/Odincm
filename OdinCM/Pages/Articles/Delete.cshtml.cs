using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OdinCM.Data.Models;
using OdinCM.Data;

namespace OdinCM.Pages.Articles
{
    [Authorize("CanDeleteArticles")]
    public class DeleteModel : PageModel
    {
        private readonly OdinCMContext _context;

        public DeleteModel(OdinCMContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Article Article { get; set; }

        public async Task<IActionResult> OnGetAsync(string slug)
        {
            if (slug == null)
            {
                return NotFound();
            }

            Article = await _context.Articles.SingleOrDefaultAsync(m => m.Slug == slug);

            if (Article == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string slug)
        {
            if (slug == null)
            {
                return NotFound();
            } 


            Article = await _context.Articles.SingleOrDefaultAsync(m => m.Slug == slug);

            if (Article != null)
            {
                _context.Articles.Remove(Article);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./All");
        }
    }
}
