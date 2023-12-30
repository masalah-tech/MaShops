using MaShops.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MaShops.Areas.ControlPanel.Controllers
{
    [Area("ControlPanel")]
    public class StoreController : Controller
    {
        private readonly AppDbContext _context;

        public StoreController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var stores =
                _context.Stores
                .Include(s => s.Owner)
                .ToList();

            return View(stores);
        }

        public IActionResult Details(int id)
        {
            var store =
                _context.Stores
                .Where(s => s.Id == id)
                .Include(s => s.Owner)
                .FirstOrDefault();

            return View(store);
        }
    }
}
