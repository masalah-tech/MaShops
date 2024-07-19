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
        private readonly string _sellerId;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(IUnitOfWork unitOfWork,
            IWebHostEnvironment webHostEnvironment)
        {
            _sellerId = "";
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
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
                }),
                ProductPhotos = new List<ProductPhoto>()
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

                var productPhotos =
                    _unitOfWork.ProductPhotoRepository
                    .GetAll();

                productVM.ProductPhotos = productPhotos;
            }

            return View(productVM);
        }

        [HttpPost]
        public IActionResult Upsert(ProductVM productVM, IFormFile mainPoster)
        {
            if (mainPoster == null)
            {
                ModelState.AddModelError("Product.MainPosterURL", "Product main poster is required");
            }

            if (ModelState.IsValid)
            {
                string rootPath = _webHostEnvironment.WebRootPath;

                if (mainPoster != null)
                {
                    string fileName = 
                        Guid.NewGuid().ToString() + Path.GetExtension(mainPoster.FileName);
                    string targetPath = Path.Combine(rootPath, @"uploads/product");

                    using (var fileStream = new FileStream(Path.Combine(targetPath, fileName), FileMode.Create))
                    {
                        mainPoster.CopyTo(fileStream);
                    }

                    productVM.Product.MainPosterURL = @"/uploads/product/" + fileName;

                    productVM.Product.StoreId =
                        _unitOfWork.StoreRepository.Get(s => s.OwnerId == _sellerId)
                        .Id;

                    _unitOfWork.ProductRepository.Add(productVM.Product);
                    _unitOfWork.Save();
                    TempData["success"] = "Product added successfully";

                    return RedirectToAction("Index");
                }

            }
            else
            {
                productVM.CategoryList = _unitOfWork.CategoryRepository.GetAll().Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                });
            }

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
