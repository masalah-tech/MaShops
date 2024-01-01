using MaShops.DataAccess.Data;
using MaShops.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace MaShops.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BannerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BannerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var banners =
                _unitOfWork.BannerRepository.GetAll();

            return View(banners);
        }
    }
}
