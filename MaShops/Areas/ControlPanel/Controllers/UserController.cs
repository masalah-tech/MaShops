using MaShops.Data;
using MaShops.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MaShops.Areas.ControlPanel.Controllers
{
    [Area("ControlPanel")]
    public class UserController : Controller
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var users =
                _context.Users
                .Include(u => u.Address)
                .ToList();

            return View(users);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            if (user.Nationality == "Select")
            {
                ModelState.AddModelError("Nationality", "The Nationality field is required.");
            }

            if (user.Address.Country == "Select")
            {
                ModelState.AddModelError("Address.Country", "The Country field is required.");
            }

            if (ModelState.IsValid)
            {
                user.Status = true;
                _context.Users.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Details(int id)
        {
            var user = 
                _context.Users
                .Where(u => u.Id == id)
                .Include(u => u.Address)
                .FirstOrDefault();

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id < 1)
            {
                return NotFound();
            }

            var user =
                _context.Users
                .Include(u => u.Address)
                .FirstOrDefault(u => u.Id == id);

            if (user == null) 
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(User user)
        {
            if (user.Nationality == "Select")
            {
                ModelState.AddModelError("Nationality", "The Nationality field is required.");
            }

            if (user.Address.Country == "Select")
            {
                ModelState.AddModelError("Address.Country", "The Country field is required.");
            }

            if (ModelState.IsValid)
            {
                _context.Users.Update(user);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Delete(int id)
        {
            var user =
                _context.Users
                .Find(id);

            if (user == null)
            {
                return NotFound();
            }

            var userCart =
                _context.Carts
                .Where(c => c.CustomerId == id)
                .FirstOrDefault();

            var userProductSaves =
                _context.ProductSaves
                .Where(ps => ps.UserId == user.Id)
                .ToList();

            var userProductReviews =
                _context.ProductsReviews
                .Where(pr => pr.CustomerId == user.Id)
                .ToList();

            var userSales =
                _context.Sales
                .Where(s => s.CustomerId == user.Id)
                .ToList();

            var userStoreSaves =
                _context.StoreSaves
                .Where(ss => ss.UserId == user.Id)
                .ToList();

            var userRoles =
                _context.UsersRoles
                .Where(ur => ur.UserId == user.Id)
                .ToList();

            if (userCart != null)
            {
                var productCart =
                    _context.ProductsCarts
                    .Where(pc => pc.Id == userCart.Id)
                    .FirstOrDefault();

                if (productCart != null)
                {
                    _context.ProductsCarts.Remove(productCart);
                }

                _context.Carts.Remove(userCart);
            }

            foreach (var saveItem in userProductSaves)
            {
                _context.ProductSaves.Remove(saveItem);
            }

            foreach (var reviewItem in userProductReviews)
            {
                _context.ProductsReviews.Remove(reviewItem);
            }

            foreach (var saleItem in userSales)
            {
                _context.Sales.Remove(saleItem);
            }

            foreach (var saveItem in userStoreSaves)
            {
                _context.StoreSaves.Remove(saveItem);
            }

            foreach (var roleItem in userRoles)
            {
                _context.UsersRoles.Remove(roleItem);
            }

            _context.Users.Remove(user);
            _context.SaveChanges();
            TempData["success"] = "User deleted successfully";
            return RedirectToAction("Index");
        }

        public IActionResult Activate(int id)
        {
            var user =
                _context.Users
                .Find(id);

            if (user == null)
            {
                return NotFound();
            }

            user.Status = true;
            _context.Users.Update(user);
            _context.SaveChanges();

            // Retrieve the referrer URL
            string referrerUrl = Request.Headers["Referer"].ToString();

            // Redirect the user back to the referrer URL
            return Redirect(referrerUrl);
        }

        public IActionResult Deactivate(int id)
        {
            var user =
                _context.Users
                .Find(id);

            if (user == null)
            {
                return NotFound();
            }

            user.Status = false;
            _context.Users.Update(user);
            _context.SaveChanges();

            // Retrieve the referrer URL
            string referrerUrl = Request.Headers["Referer"].ToString();

            // Redirect the user back to the referrer URL
            return Redirect(referrerUrl);
        }

        //public IActionResult Edit(int id)
        //{
        //    var user =
        //        _context.Users
        //        .Where(u => u.Id == id)
        //        .Include(u => u.Address)
        //        .FirstOrDefault();

        //    return View(user);
        //}
    }
}
