using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NodaTime;
using OdinCM.Data;
using OdinCM.Data.Models;
using OdinCM.Models;

namespace OdinCM.Pages.Customers
{
    public class CreateModel : PageModel
    {
        private readonly OdinCMContext _context;
        private readonly IClock _clock;


        public CreateModel(OdinCMContext context, IClock clock)
        {
            _context = context;
            _clock = clock;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Customer Customer { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            Customer.UpdatedAt = _clock.GetCurrentInstant();
            Customer.CreatedAt = _clock.GetCurrentInstant();

            _context.Customer.Add(Customer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}