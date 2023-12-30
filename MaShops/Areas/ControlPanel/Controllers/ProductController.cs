using MaShops.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MaShops.Areas.ControlPanel.Controllers
{
    [Area("ControlPanel")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var products =
                _context.Products
                .Include(p => p.Store)
                .Include(p => p.Category)
                .ToList();

            return View(products);
        }

        public IActionResult Details(int id)
        {
            var product =
                _context.Products
                .Where(p => p.Id == id)
                .Include(p => p.Category)
                .Include(p => p.Store)
                .FirstOrDefault();

            return View(product);
        }
    }
}
