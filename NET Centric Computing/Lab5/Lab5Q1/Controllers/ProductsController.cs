using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab5Q1.Data;

namespace Lab5Q1.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppDbContext _context;
        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _context.Products.AsNoTracking().ToListAsync();
            return View(products);
        }
    }
}
