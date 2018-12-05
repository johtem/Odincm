using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdinCM.Data.Models;

namespace OdinCM.Pages.Components.ListComments
{
    [ViewComponent(Name = "ListComments")]
    public class ListComments : ViewComponent
    {

        public ListComments()
        {

        }

        public IViewComponentResult Invoke(ICollection<Comment> comments)
        {
            return View("ListComments", comments);
        }
    }
}