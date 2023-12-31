using MaShops.DataAccess.Data;
using MaShops.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace MaShops.Areas.ControlPanel.Controllers
{
    [Area("ControlPanel")]
    public class BannerController : Controller
    {
        private readonly IBannerRepository _bannerRepository;

        public BannerController(IBannerRepository bannerRepository)
        {
            _bannerRepository = bannerRepository;
        }
        public IActionResult Index()
        {
            var banners =
                _bannerRepository.GetAll();

            return View(banners);
        }
    }
}
