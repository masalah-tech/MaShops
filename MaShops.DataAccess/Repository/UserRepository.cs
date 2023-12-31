    using MaShops.DataAccess.Data;
using MaShops.DataAccess.Repository.IRepository;
using MaShops.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MaShops.DataAccess.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
            : base(context)
        {
            _context = context;
        }
        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
        }

        public override IEnumerable<User> GetAll()
        {
            return _context.Users
                .Include(u => u.Address)
                .ToList();
        }

        public override User Get(Expression<Func<User, bool>> filter)
        {
            return _context.Users
                .Where(filter)
                .Include(u => u.Address)
                .FirstOrDefault();
        }

        public override void Remove(User user)
        {
            var userCart =
                _context.Carts
                .Where(c => c.CustomerId == user.Id)
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
        }
    }
}
