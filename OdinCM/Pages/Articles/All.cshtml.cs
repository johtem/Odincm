using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OdinCM.Models;

namespace OdinCM.Pages.Articles
{
    public class AllModel : PageModel
    {
        private readonly OdinCMContext _Context;
        private const int _PageSize = 2;

        public AllModel(OdinCMContext Context)
        {
            _Context = Context;
        }

        [FromQuery()]
        public int PageNumber { get; set; } = 1;

        public int TotalPages { get; set; }

        public IEnumerable<Article> Articles { get; set; }


        public async Task OnGet()
        {
            Articles = await _Context.Articles
                .AsNoTracking()
                .OrderBy(a => a.Topic)
                .Skip((PageNumber -1) * _PageSize)
                .Take(_PageSize)
                .ToArrayAsync();

            TotalPages = (int)Math.Ceiling((await _Context.Articles.CountAsync()) / (double) _PageSize);

        }
    }
}