using MaShops.DataAccess.Data;
using MaShops.DataAccess.Repository.IRepository;
using MaShops.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MaShops.Areas.ControlPanel.Controllers
{
    [Area("ControlPanel")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public IActionResult Index()
        {
            var users =
                _userRepository.GetAll();

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
                _userRepository.Add(user);
                _userRepository.Save();
                TempData["success"] = "User created successfully";
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Details(int id)
        {
            var user =
                _userRepository.Get(u => u.Id == id);

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
                _userRepository.Get(u => u.Id == id);

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
                _userRepository.Update(user);
                _userRepository.Save();
                TempData["success"] = "User edited successfully";
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Delete(int id)
        {
            var user =
                _userRepository
                .Get(u => u.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            _userRepository.Remove(user);
            _userRepository.Save();

            TempData["success"] = "User deleted successfully";
            return RedirectToAction("Index");
        }

        public IActionResult Activate(int id)
        {
            var user =
                _userRepository
                .Get(u => u.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            user.Status = true;
            _userRepository.Update(user);
            _userRepository.Save();

            TempData["success"] = 
                "User activated successfully";

            // Retrieve the referrer URL
            string refererUrl = Request.Headers["Referer"].ToString();

            // Redirect the user back to the referrer URL
            return Redirect(refererUrl);
        }

        public IActionResult Deactivate(int id)
        {
            var user =
                _userRepository
                .Get(u => u.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            user.Status = false;
            _userRepository.Update(user);
            _userRepository.Save();

            TempData["success"] =
                "User deactivated successfully";

            // Retrieve the referrer URL
            string refererUrl = Request.Headers["Referer"].ToString();

            // Redirect the user back to the referrer URL
            return Redirect(refererUrl);
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
