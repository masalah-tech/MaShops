using MaShops.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MaShops.Areas.ControlPanel.Controllers
{
    [Area("ControlPanel")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var categories =
                _context.Categories
                .ToList();

            return View(categories);
        }

        public IActionResult CategoryProducts(int id)
        {
            var products =
                _context.Products
                .Where(p => p.CategoryId == id)
                .Include(p => p.Store)
                .Include(p => p.Category)
                .ToList();

            return View(products);
        }
    }
}
