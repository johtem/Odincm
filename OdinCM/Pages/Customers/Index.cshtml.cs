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

        public IndexModel(OdinCM.Models.OdinCMContext context)
        {
            _context = context;
        }

        public IList<Customer> Customer { get;set; }

        public async Task OnGetAsync(string searchString)
        {
            ViewData["SearchString"] = searchString;

            var customers = from m in _context.Customer
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                customers = customers.Where(s => s.CustomerName.Contains(searchString));
            }

            Customer = await customers.OrderBy(s => s.CustomerName).ToListAsync();
          
        }
    }
}
