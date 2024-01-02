using MaShops.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace MaShops.Areas.Seller.Controllers
{
    [Area("Seller")]
    public class SettingsController : Controller
    {
        private readonly int _sellerId;
        private readonly IUnitOfWork _unitOfWork;

        public SettingsController(IUnitOfWork unitOfWork)
        {
            _sellerId = 6;
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var store =
                _unitOfWork.StoreRepository
                .Get(s => s.OwnerId == _sellerId);

            if (store == null)
            {
                return NotFound();
            }

            return View(store);
        }
    }
}
