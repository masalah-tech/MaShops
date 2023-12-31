using MaShops.DataAccess.Data;
using MaShops.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MaShops.Areas.ControlPanel.Controllers
{
    [Area("ControlPanel")]
    public class StoreController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public StoreController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var stores =
                _unitOfWork.StoreRepository
                .GetAll();

            return View(stores);
        }

        public IActionResult Details(int id)
        {
            var store =
                _unitOfWork.StoreRepository
                .Get(s => s.Id == id);

            return View(store);
        }

        public IActionResult Delete(int id) 
        {
            var store =
                _unitOfWork.StoreRepository
                .Get(s => s.Id == id);

            _unitOfWork.StoreRepository.Remove(store);
            _unitOfWork.Save();
            TempData["Success"] = "Store deleted successfully";

            return RedirectToAction("Index");
        }

        public IActionResult Activate(int id) 
        {
            var store =
                _unitOfWork.StoreRepository
                .Get(s => s.Id == id);

            if (store == null)
            {
                return NotFound();
            }

            store.Status = true;
            _unitOfWork.StoreRepository.Update(store);
            _unitOfWork.Save();
            TempData["Success"] = "Store activated successfully";

            var refererUrl = Request.Headers["Referer"].ToString();

            return Redirect(refererUrl);
        }

        public IActionResult Deactivate(int id)
        {
            var store =
                _unitOfWork.StoreRepository
                .Get(s => s.Id == id);

            if (store == null)
            {
                return NotFound();
            }

            store.Status = false;
            _unitOfWork.StoreRepository.Update(store);
            _unitOfWork.Save();

            TempData["success"] = "Store deactivated successfully";

            var refererUrl = Request.Headers["Referer"].ToString();

            return Redirect(refererUrl);
        }
    }
}
