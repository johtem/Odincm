using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OdinCM.Data;
using OdinCM.Data.Data.Interfaces;
using OdinCM.Data.Models;


namespace OdinCM.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private readonly ICustomerRepository _customerRepo;

        public IndexModel(ICustomerRepository customerRepo)
        {
            _customerRepo = customerRepo;
        }

        [FromRoute]
        public int PageNumber { get; set; } = 1;

        [BindProperty]
        public int PageSize { get; set; } = 3;

        public SelectList PageSizeOptions { get; set; }

        public int TotalPages { get; set; }

        public IEnumerable<Customer> Customers { get; set; }

       

        public async Task OnGet(int pageNumber = 1)
        {
            ManagePageSize();
            Customers = await _customerRepo.GetAllCustomersPaged(PageSize, pageNumber);
            TotalPages = await _customerRepo.GetTotalPagesOfCustomers(PageSize);

        }


        private void ManagePageSize()
        {
            if (int.TryParse(Request.Cookies["PageSize"], out var pageSize) == false)
            {
                pageSize = 20;
                Response.Cookies.Append("PageSize", pageSize.ToString());
            }

            var selectPageSizes = new List<int> { 2, 5, 10, 20, 40 };
            if (selectPageSizes.Contains(pageSize) == false)
            {
                selectPageSizes.Insert(0, pageSize);
            }
            PageSizeOptions = new SelectList(selectPageSizes);
            PageSize = pageSize;
        }
    }
}
