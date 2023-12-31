using MaShops.DataAccess.Data;
using MaShops.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MaShops.Areas.ControlPanel.Controllers
{
    [Area("ControlPanel")]
    public class StoreController : Controller
    {
        private readonly IStoreRepository _storeRepository;

        public StoreController(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }
        public IActionResult Index()
        {
            var stores =
                _storeRepository.GetAll();

            return View(stores);
        }

        public IActionResult Details(int id)
        {
            var store =
                _storeRepository.Get(s => s.Id == id);

            return View(store);
        }

        public IActionResult Delete(int id) 
        {
            var store =
                _storeRepository
                .Get(s => s.Id == id);

            _storeRepository.Remove(store);
            _storeRepository.Save();
            TempData["Success"] = "Store deleted successfully";

            return RedirectToAction("Index");
        }

        public IActionResult Activate(int id) 
        {
            var store =
                _storeRepository
                .Get(s => s.Id == id);

            if (store == null)
            {
                return NotFound();
            }

            store.Status = true;
            _storeRepository.Update(store);
            _storeRepository.Save();
            TempData["Success"] = "Store activated successfully";

            var refererUrl = Request.Headers["Referer"].ToString();

            return Redirect(refererUrl);
        }

        public IActionResult Deactivate(int id)
        {
            var store =
                _storeRepository
                .Get(s => s.Id == id);

            if (store == null)
            {
                return NotFound();
            }

            store.Status = false;
            _storeRepository.Update(store);
            _storeRepository.Save();

            TempData["success"] = "Store deactivated successfully";

            var refererUrl = Request.Headers["Referer"].ToString();

            return Redirect(refererUrl);
        }
    }
}
