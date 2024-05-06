using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using System.Security.Principal;

namespace RZAWebApp.Controllers
{
    [Authorize(Roles = "Admin,Writer")]
    public class StaffController : Controller
    {
        public IActionResult StaffPortal()
        {
            return View();
        }
    }
}
