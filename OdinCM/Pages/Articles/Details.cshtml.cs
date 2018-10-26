﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OdinCM.Models;

namespace OdinCM.Pages.Articles
{
    public class DetailsModel : PageModel
    {
        private readonly OdinCM.Models.OdinCMContext _context;

        public DetailsModel(OdinCM.Models.OdinCMContext context)
        {
            _context = context;
        }

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
    }
}
