﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OdinCM.Models;
using NodaTime;
using OdinCM.Helpers;

namespace OdinCM.Pages.Articles
{
    public class DetailsModel : PageModel
    {
        private readonly OdinCM.Models.OdinCMContext _context;
        private readonly IClock _clock;

        public DetailsModel(OdinCM.Models.OdinCMContext context, IClock clock)
        {
            _context = context;
            _clock = clock;
        }

        public Article Article { get; set; }

        public async Task<IActionResult> OnGetAsync(string slug)
        {
            slug = slug ?? "homepage";


            Article = await _context.Articles.FirstOrDefaultAsync(m => m.Slug == slug.ToLower());
            Article = await _context.Articles.Include(x => x.Comments).SingleOrDefaultAsync(m => m.Slug == slug.ToLower());

            if (Article == null)
            {
                return new ArticleNotFoundResult();
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

            return Redirect($"/Articles/{Article.Slug}");
        }
    }
}
