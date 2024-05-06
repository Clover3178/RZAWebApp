using Microsoft.AspNetCore.Mvc;

namespace RZAWebApp.Controllers
{
    public class WebContentController : Controller
    {
        public IActionResult Articles()
        {
            return View();
        }

        public IActionResult Map()
        {
            return View();
        }

        public IActionResult Booking()
        {
            return View();
        }
    }
}
