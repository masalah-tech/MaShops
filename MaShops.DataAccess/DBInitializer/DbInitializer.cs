using MaShops.DataAccess.Data;
using MaShops.Models;
using MaShops.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaShops.DataAccess.DBInitializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppDbContext _context;

        public DbInitializer(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            AppDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        public void Initialize()
        {
            try
            {
                if (_context.Database.GetPendingMigrations().Count() > 0)
                    _context.Database.Migrate();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            if (!_roleManager.RoleExistsAsync(SD.Role_SuperAdmin).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(SD.Role_SuperAdmin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Seller)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Customer)).GetAwaiter().GetResult();

                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "masalah.tech@gmail.com",
                    Email = "masalah.tech@gmail.com",
                    FirstName = "Mazen",
                    SecondName = "Ameen",
                    ThirdName = "Hamid",
                    LastName = "Salah",
                    PhoneNumber = "00967774806897",
                }, "P@$$w0rd").GetAwaiter().GetResult();

                ApplicationUser user =
                    _context.ApplicationUsers.First(x => x.Email == "masalah.tech@gmail.com");

                _userManager.AddToRoleAsync(user, SD.Role_SuperAdmin).GetAwaiter().GetResult();
            }
        }
    }
}
