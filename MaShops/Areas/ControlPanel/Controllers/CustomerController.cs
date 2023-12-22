using MaShops.Data;
using MaShops.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MaShops.Areas.ControlPanel.Controllers
{
    [Area("ControlPanel")]
    public class CustomerController : Controller
    {
        private readonly AppDbContext _context;

        public CustomerController(AppDbContext context)
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

            List<User> customers = new List<User>();

            foreach (var userRole in userRoles)
            {
                foreach (var user in users)
                {
                    if (userRole.UserId == user.Id
                        && userRole.Role.Title == "Admin")
                    {
                        customers.Add(user);
                    }
                }
            }

            return View(customers);
        }

        public IActionResult Details(int id)
        {
            var customer =
                _context.Users
                .Where(u => u.Id == id)
                .Include(u => u.Address)
                .FirstOrDefault();

            return View(customer);
        }

        public IActionResult Edit(int id)
        {
            var customer =
                _context.Users
                .Where(u => u.Id == id)
                .Include(u => u.Address)
                .FirstOrDefault();

            return View(customer);
        }
    }
}
