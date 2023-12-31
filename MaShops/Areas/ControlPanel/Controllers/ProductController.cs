using MaShops.DataAccess.Data;
using MaShops.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MaShops.Areas.ControlPanel.Controllers
{
    [Area("ControlPanel")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public IActionResult Index()
        {
            var products =
                _productRepository.GetAll();

            return View(products);
        }

        public IActionResult Details(int id)
        {
            var product =
                _productRepository.Get(p => p.Id == id);

            return View(product);
        }

        public IActionResult Delete(int id)
        {
            var product =
                _productRepository.Get(p => p.Id == id);

            _productRepository.Remove(product);
            _productRepository.Save();
            TempData["success"] = "Product deleted successfully";

            return RedirectToAction("Index");
        }
    }
}
