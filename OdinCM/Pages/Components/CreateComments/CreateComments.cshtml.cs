using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdinCM.Data;
using OdinCM.Data.Models;

namespace OdinCM.Pages.Components.CreateComments
{
    [ViewComponent(Name = "CreateComments")]
    public class CreateComments : ViewComponent
    {
        private readonly OdinCMContext _context;

        public CreateComments(IOdinCMContext context)
        {
            this._context = (OdinCMContext)context;
        }

        public IViewComponentResult Invoke(Comment comment)
        {
            return View("CreateComments", comment);
        }
    }
}