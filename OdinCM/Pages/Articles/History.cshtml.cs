using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiffPlex.DiffBuilder;
using DiffPlex.DiffBuilder.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OdinCM.Helpers;
using OdinCM.Data.Models;
using OdinCM.Data;
using OdinCM.Data.Data.Interfaces;

namespace OdinCM.Pages.Articles
{
    public class HistoryModel : PageModel
    {
        private readonly IArticleRepository _articleRepo;

        public HistoryModel(IArticleRepository articleRepo)
        {
            _articleRepo = articleRepo;
        }

        
        public Article Article { get; private set; }

        [BindProperty()]
        public string[] Compare { get; set; }

        public SideBySideDiffModel DiffModel { get; set; }

        public async Task<IActionResult> OnGetAsync(string slug)
        {
            if (string.IsNullOrEmpty(slug))
            {
                return NotFound();
            }

            Article = await _articleRepo.GetArticleWithHistoriesBySlug(slug);
            
            if (Article == null)
            {
                return new ArticleNotFoundResult();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string slug)
        {

            Article = await _articleRepo.GetArticleWithHistoriesBySlug(slug);

            var histories = Article.History
                .Where(h => Compare.Any(c => c == h.Version.ToString()))
                .OrderBy(h => h.Version)
                .ToArray();

            this.DiffModel = new SideBySideDiffBuilder(new DiffPlex.Differ())
                .BuildDiffModel(histories[0].Content, histories[1].Content);


            return Page();
        }
    }
}