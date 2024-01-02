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
            _sellerId = 5;
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

        public IActionResult DeleteStore() 
        {
            var store =
                _unitOfWork.StoreRepository
                .Get(s => s.OwnerId == _sellerId);

            if (store == null)
            {
                return NotFound();
            }

            _unitOfWork.StoreRepository.Remove(store);
            _unitOfWork.Save();

            TempData["Success"] = "Store deleted successfully";

            return RedirectToAction("Index", "Home");
        }

        public IActionResult DeleteUserAccount()
        {
            var user =
                _unitOfWork.UserRepository
                .Get(s => s.Id == _sellerId);

            if (user == null)
            {
                return NotFound();
            }

            _unitOfWork.UserRepository.Remove(user);
            _unitOfWork.Save();

            TempData["Success"] = "Account deleted successfully";

            return RedirectToAction("Index", "Home");
        }
    }
}
