using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RZAWebApp.Views.Home
{
    public class ContactModel : PageModel
    {
        public void OnGet()
        {
            ViewData["Title"] = "Contact Us";
        }
    }
}
