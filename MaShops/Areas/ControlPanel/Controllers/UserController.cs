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

            return View(user);
        }

        public IActionResult Edit(int id)
        {
            var user =
                _context.Users
                .Where(u => u.Id == id)
                .Include(u => u.Address)
                .FirstOrDefault();

            return View(user);
        }
    }
}
