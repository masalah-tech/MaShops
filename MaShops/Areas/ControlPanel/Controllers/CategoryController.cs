using MaShops.DataAccess.Data;
using MaShops.DataAccess.Repository.IRepository;
using MaShops.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MaShops.Areas.ControlPanel.Controllers
{
    [Area("ControlPanel")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public IActionResult Index()
        {
            var categories =
                _categoryRepository
                .GetAll();

            return View(categories);
        }
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category) 
        {
            if (ModelState.IsValid) 
            { 
                _categoryRepository.Add(category);
                _categoryRepository.Save();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id < 1)
            {
                return NotFound();
            }

            var category =
                _categoryRepository.Get(c => c.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryRepository.Update(category);
                _categoryRepository.Save();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Delete(int id)
        {
            var category =
                _categoryRepository
                .Get(c => c.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            _categoryRepository.Remove(category);
            _categoryRepository.Save();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
        }

        //public IActionResult CategoryProducts(int id)
        //{
        //    var products =
        //        _context.Products
        //        .Where(p => p.CategoryId == id)
        //        .Include(p => p.Store)
        //        .Include(p => p.Category)
        //        .ToList();

        //    return View(products);
        //}
    }
}
