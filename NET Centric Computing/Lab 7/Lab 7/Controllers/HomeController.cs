using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Lab7.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // Check if user is logged in
            var username = HttpContext.Session.GetString("username");
            if (string.IsNullOrEmpty(username))
            {
                return RedirectToAction("Login", "Account");
            }

            ViewBag.Username = username;
            return View();
        }
    }
}
