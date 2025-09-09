using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Lab7.Controllers
{
    public class AccountController : Controller
    {
        // Hardcoded users
        private readonly Dictionary<string, string> users = new Dictionary<string, string>()
        {
            { "sulav", "sulav123" },
            { "messi", "messi" },
        };

        // GET: /Account/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (users.ContainsKey(username) && users[username] == password)
            {
                // Store username in session
                HttpContext.Session.SetString("username", username);
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Invalid username or password!";
            return View();
        }

        // GET: /Account/Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
