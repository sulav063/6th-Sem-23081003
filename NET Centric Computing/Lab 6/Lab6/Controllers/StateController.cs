using Microsoft.AspNetCore.Mvc;

namespace lab6q1.Controllers
{
    public class StateController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // ViewData & ViewBag
        public IActionResult ViewDataDemo()
        {
            ViewData["Msg"] = "Hello from ViewData";
            ViewBag.Note = "Hello from ViewBag";
            return View();
        }

        // TempData
        public IActionResult TempDataSet()
        {
            TempData["Msg"] = "This is from TempData (works for one redirect)";
            return RedirectToAction("TempDataRead");
        }

        public IActionResult TempDataRead()
        {
            return View();
        }

        // Session
        public IActionResult SessionSet()
        {
            HttpContext.Session.SetString("User", "Sulav");
            return RedirectToAction("SessionGet");
        }

        public IActionResult SessionGet()
        {
            return View();
        }

        // Cookie
        public IActionResult CookieSet()
        {
            Response.Cookies.Append("Theme", "Dark");
            return RedirectToAction("CookieGet");
        }

        public IActionResult CookieGet()
        {
            return View();
        }
    }
}
