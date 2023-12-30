using MaShops.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;

namespace MaShops.Areas.ControlPanel.Controllers
{
    [Area("ControlPanel")]
    public class BannerController : Controller
    {
        private readonly AppDbContext _context;

        public BannerController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var banners =
                _context.Banners.OrderByDescending(b => b.Status).ToList();

            return View(banners);
        }
    }
}
