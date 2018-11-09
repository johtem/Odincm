using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdinCM.Models;

namespace OdinCM.Pages.Components.CreateComments
{
    [ViewComponent(Name = "CreateComments")]
    public class CreateComments : ViewComponent
    {
        private readonly OdinCMContext _context;

        public CreateComments(OdinCMContext context)
        {
            this._context = context;
        }

        public IViewComponentResult Invoke(Comment comment)
        {
            return View("CreateComments", comment);
        }
    }
}