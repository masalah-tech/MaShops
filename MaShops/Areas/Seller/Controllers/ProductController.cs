using MaShops.DataAccess.Repository;
using MaShops.DataAccess.Repository.IRepository;
using MaShops.Models;
using MaShops.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MaShops.Areas.Seller.Controllers
{
    [Area("Seller")]
    public class ProductController : Controller
    {
        private readonly int _sellerId;
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _sellerId = 6;
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var store =
                _unitOfWork.StoreRepository
                .Get(s => s.OwnerId == _sellerId);

            var products =
                _unitOfWork.ProductRepository
                .GetRange(p => p.StoreId == store.Id);

            return View(products);
        }

        public IActionResult Details(int id) 
        {
            var product =
                _unitOfWork.ProductRepository
                .Get(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        public IActionResult Upsert(int? id)
        {
            ProductVM productVM = new ProductVM
            {
                Product = new Product(),
                CategoryList = _unitOfWork.CategoryRepository.GetAll().Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                })
            };

            if (id != 0 && id != null)
            {
                var product =
                    _unitOfWork.ProductRepository
                    .Get(p => p.Id == id);

                if (product == null)
                {
                    return NotFound();
                }

                productVM.Product = product;
            }

            return View(productVM);
        }

        [HttpPost]
        public IActionResult Upsert(ProductVM productVM)
        {
            //ProductVM productVM = new ProductVM
            //{
            //    Product = new Product(),
            //    CategoryList = _unitOfWork.CategoryRepository.GetAll().Select(c => new SelectListItem
            //    {
            //        Text = c.Name,
            //        Value = c.Id.ToString()
            //    })
            //};

            //if (id != 0 && id != null)
            //{
            //    var product =
            //        _unitOfWork.ProductRepository
            //        .Get(p => p.Id == id);

            //    if (product == null)
            //    {
            //        return NotFound();
            //    }

            //    productVM.Product = product;
            //}

            return View(productVM);
        }

        [HttpPost]
        public IActionResult Edit(ProductVM productVM)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.ProductRepository.Update(productVM.Product);
                _unitOfWork.Save();
                TempData["success"] = "Product updated successfully";
            }
            else
            {
                productVM = new ProductVM
                {
                    Product = productVM.Product,
                    CategoryList = _unitOfWork.CategoryRepository.GetAll().Select(c => new SelectListItem
                    {
                        Text = c.Name,
                        Value = c.Id.ToString()
                    })
                };
            }

            return View(productVM);
        }

        public IActionResult Delete(int id)
        {
            var product =
                _unitOfWork.ProductRepository
                .Get(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            _unitOfWork.ProductRepository.Remove(product);
            _unitOfWork.Save();
            TempData["success"] = "Product removed successfully";

            return RedirectToAction("Index");
        }
    }
}
