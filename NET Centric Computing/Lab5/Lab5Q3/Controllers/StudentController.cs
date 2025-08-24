using Microsoft.AspNetCore.Mvc;
using Lab5Q3.Models;

namespace Lab5Q3.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student/Index
        public IActionResult Index()
        {
            return View();
        }

        // POST: Student/Index
        [HttpPost]
        public IActionResult Index(Student student)
        {
            if (ModelState.IsValid)
            {
                return View("StudentDetails", student);
            }
            return View(student);
        }
    }
}
