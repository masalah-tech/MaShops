using MaShops.DataAccess.Data;
using MaShops.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MaShops.Areas.ControlPanel.Controllers
{
    [Area("ControlPanel")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var products =
                _unitOfWork.ProductRepository
                .GetAll();

            return View(products);
        }

        public IActionResult Details(int id)
        {
            var product =
                _unitOfWork.ProductRepository
                .Get(p => p.Id == id);

            return View(product);
        }

        public IActionResult Delete(int id)
        {
            var product =
                _unitOfWork.ProductRepository
                .Get(p => p.Id == id);

            _unitOfWork.ProductRepository.Remove(product);
            _unitOfWork.Save();
            TempData["success"] = "Product deleted successfully";

            return RedirectToAction("Index");
        }
    }
}
