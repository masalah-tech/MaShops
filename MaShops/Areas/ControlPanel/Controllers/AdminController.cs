using MaShops.Data;
using MaShops.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MaShops.Areas.ControlPanel.Controllers
{
    [Area("ControlPanel")]
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;

        public AdminController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var userRoles =
                _context.UsersRoles
                .Include(ur => ur.Role)
                .ToList();

            var users =
                _context.Users
                .Include(u => u.Address)
                .ToList();

            List<User> admins = new List<User>();

            foreach (var userRole in userRoles)
            {
                foreach (var user in users)
                {
                    if (userRole.UserId == user.Id
                        && userRole.Role.Title == "Admin")
                    {
                        admins.Add(user);
                    }
                }
            }

            return View(admins);
        }

        public IActionResult Details(int id)
        {
            var admin =
                _context.Users
                .Where(u => u.Id == id)
                .Include(u => u.Address)
                .FirstOrDefault();

            return View(admin);
        }

        public IActionResult Edit(int id)
        {
            var admin =
                _context.Users
                .Where(u => u.Id == id)
                .Include(u => u.Address)
                .FirstOrDefault();

            return View(admin);
        }
    }
}
