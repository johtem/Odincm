using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OdinCM.Models;

namespace OdinCM.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private readonly OdinCM.Models.OdinCMContext _context;
        private const int _PageSize = 2;

        public IndexModel(OdinCM.Models.OdinCMContext context)
        {
            _context = context;
        }

        [FromQuery()]
        public int PageNumber { get; set; } = 1;

        public int TotalPages { get; set; }

        public List<Customer> Customers { get; set; }

        
        public async Task OnGetAsync(string searchString)
        {
            ViewData["SearchString"] = searchString;


            // Customers = await _context.Customer
            //    .AsNoTracking()
            //    .OrderBy(a => a.CustomerName)
            //    .Skip((PageNumber - 1) * _PageSize)
            //    .Take(_PageSize)
            //    .ToArrayAsync();
           
            TotalPages = (int)Math.Ceiling((await _context.Customer.CountAsync()) / (double)_PageSize);

            var customers = from m in _context.Customer
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                customers = customers.Where(s => s.CustomerName.Contains(searchString));
            }

            Customers = await customers.OrderBy(s => s.CustomerName)
                .Skip((PageNumber - 1) * _PageSize)
                .Take(_PageSize)
                .ToListAsync();

        }
    }
}
