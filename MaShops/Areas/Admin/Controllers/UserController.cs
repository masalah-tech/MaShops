using MaShops.DataAccess.Data;
using MaShops.DataAccess.Repository.IRepository;
using MaShops.Models;
using MaShops.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MaShops.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var users =
                _unitOfWork.UserRepository
                .GetAll();

            return View(users);
        }

        public IActionResult Create()
        {
            //var user = new ApplicationUser();

            //var userRoles = new List<UserRole>
            //{
            //    new UserRole
            //    {
            //        UserId = user.Id,                
            //    }
            //};

            //IEnumerable<SelectListItem> roleList =
            //    _unitOfWork.RoleRepository
            //        .GetRange(c => c.Title != "Seller")
            //        .Select(c => new SelectListItem
            //        {
            //            Text = c.Title,
            //            Value = c.Id.ToString()
            //        });

            //var userVM = new UserVM
            //{
            //    User = user,
            //    UserRoles = userRoles,
            //    RoleList = roleList
            //};

            //return View(userVM);

            return View();
        }

        [HttpPost]
        public IActionResult Create(UserVM userVM)
        {

            //if (ModelState.IsValid)
            //{
            //    userVM.User.Status = true;

            //    _unitOfWork.UserRepository.Add(userVM.User);
            //    _unitOfWork.Save();

            //    userVM.UserRoles[0].UserId = userVM.User.Id;
            //    _unitOfWork.UserRoleRepository.Add(userVM.UserRoles[0]);
            //    _unitOfWork.Save();

            //    TempData["success"] = "User created successfully";
            //    return RedirectToAction("Index");
            //}
            //else
            //{
            //    userVM.RoleList = 
            //        _unitOfWork.RoleRepository
            //        .GetRange(c => c.Title != "Seller")
            //        .Select(c => new SelectListItem
            //    {
            //        Text = c.Title,
            //        Value = c.Id.ToString()
            //    });
            //}

            return View(userVM);
        }

        public IActionResult Details(int id)
        {
            //var user =
            //    _unitOfWork.UserRepository
            //    .Get(u => u.Id == id);

            //if (user == null)
            //{
            //    return NotFound();
            //}

            //return View(user);

            return View();
        }

        public IActionResult Edit(int? id)
        {
            //IEnumerable<SelectListItem> roleList =
            //    _unitOfWork.RoleRepository
            //        .GetRange(c => c.Title == "Super Admin" || c.Title == "Admin")
            //        .Select(c => new SelectListItem
            //        {
            //            Text = c.Title,
            //            Value = c.Id.ToString()
            //        });

            //var user =
            //    _unitOfWork.UserRepository
            //    .Get(u => u.Id == id);

            //if (user == null) 
            //{
            //    return NotFound();
            //}

            //var userRoles = 
            //    _unitOfWork.UserRoleRepository
            //    .GetRange(ur => ur.UserId == id)
            //    .ToList();

            //var userVM = new UserVM
            //{
            //    RoleList = roleList,
            //    User = user,
            //    UserRoles = userRoles
            //};

            //return View(userVM);

            return View();
        }

        [HttpPost]
        public IActionResult Edit(ApplicationUser user)
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
                _unitOfWork.UserRepository
                    .Update(user);
                _unitOfWork.Save();
                TempData["success"] = "User edited successfully";
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Delete(int id)
        {
            //    var user =
            //        _unitOfWork.UserRepository
            //        .Get(u => u.Id == id);

            //    if (user == null)
            //    {
            //        return NotFound();
            //    }

            //    _unitOfWork.UserRepository.Remove(user);
            //    _unitOfWork.Save();

            //    TempData["success"] = "User deleted successfully";
            //    return RedirectToAction("Index");
            //}

            //public IActionResult Activate(int id)
            //{
            //    var user =
            //        _unitOfWork.UserRepository
            //        .Get(u => u.Id == id);

            //    if (user == null)
            //    {
            //        return NotFound();
            //    }

            //    //user.Status = true;
            //    _unitOfWork.UserRepository.Update(user);
            //    _unitOfWork.Save();

            //    TempData["success"] = 
            //        "User activated successfully";

            // Retrieve the referrer URL
            string refererUrl = Request.Headers["Referer"].ToString();

            // Redirect the user back to the referrer URL
            return Redirect(refererUrl);
        }

        public IActionResult Deactivate(int id)
        {
            //var user =
            //    _unitOfWork.UserRepository
            //    .Get(u => u.Id == id);

            //if (user == null)
            //{
            //    return NotFound();
            //}

            ////user.Status = false;
            //_unitOfWork.UserRepository.Update(user);
            //_unitOfWork.Save();

            //TempData["success"] =
            //    "User deactivated successfully";

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
