using MaShops.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MaShops.Areas.ControlPanel.Controllers
{
    [Area("ControlPanel")]
    public class SaleController : Controller
    {
        private readonly AppDbContext _context;

        public SaleController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var sales =
                _context.Sales
                .Include(s => s.Customer)
                .Include(s => s.Product)
                .Include(s => s.Product.Store)
                .OrderByDescending(s => s.DateTime)
                .ToList();

            return View(sales);
        }

        public IActionResult Details(int id)
        {
            var sale =
                _context.Sales
                .Where(s => s.Id == id)
                .Include(s => s.Customer)
                .Include(s => s.Product)
                .Include(s => s.Product.Store)
                .Include(s => s.Product.Category)
                .FirstOrDefault();

            return View(sale);
        }

    }
}
