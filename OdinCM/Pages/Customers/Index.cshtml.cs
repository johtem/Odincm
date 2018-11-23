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
        private const int _PageSize = 10;

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

            var customers = from m in _context.Customer
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                customers = customers.Where(s => s.CustomerName.Contains(searchString));
                TotalPages = (int)Math.Ceiling((await _context.Customer.Where(s => s.CustomerName.Contains(searchString)).CountAsync()) / (double)_PageSize);
            } else
            {
                TotalPages = (int)Math.Ceiling((await _context.Customer.CountAsync()) / (double)_PageSize);
            }

            Customers = await customers.OrderBy(s => s.CustomerName)
                .Skip((PageNumber - 1) * _PageSize)
                .Take(_PageSize)
                .ToListAsync();

        }
    }
}
