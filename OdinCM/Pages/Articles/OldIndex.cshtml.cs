using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OdinCM.Data;
using OdinCM.Data.Models;

namespace OdinCM.Pages.Articles
{
    public class IndexModel : PageModel
    {
        private readonly OdinCMContext _context;

        public IndexModel(OdinCMContext context)
        {
            _context = context;
        }

        public IList<Article> Article { get;set; }

        public async Task OnGetAsync()
        {
            Article = await _context.Articles.ToListAsync();
        }
    }
}
