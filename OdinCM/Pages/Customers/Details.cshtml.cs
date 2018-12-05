using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OdinCM.Data;
using OdinCM.Data.Data.Interfaces;
using OdinCM.Data.Models;


namespace OdinCM.Pages.Customers
{
    public class DetailsModel : PageModel
    {
        private readonly ICustomerRepository _customerRepo;

        public DetailsModel(ICustomerRepository customerRepo)
        {
            _customerRepo = customerRepo;
        }

        public Customer Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer = await _customerRepo.GetCustomerById(id);

            if (Customer == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
