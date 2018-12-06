using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdinCM.Data;
using OdinCM.Data.Data.Interfaces;
using OdinCM.Data.Models;

namespace OdinCM.Pages.Components.CreateComments
{
    [ViewComponent(Name = "CreateComments")]
    public class CreateComments : ViewComponent
    {
       
        public IViewComponentResult Invoke(Comment comment)
        {
            return View("CreateComments", comment);
        }
    }
}