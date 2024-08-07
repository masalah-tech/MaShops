﻿    using MaShops.DataAccess.Data;
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
    public class UserRepository : Repository<ApplicationUser>, IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
            : base(context)
        {
            _context = context;
        }

        public void Update(ApplicationUser user)
        {
            _context.Users.Update(user);
        }

        public override IEnumerable<ApplicationUser> GetAll()
        {
            return _context.Users
                .Include(u => u.Address)
                .ToList();
        }

        public override ApplicationUser Get(Expression<Func<ApplicationUser, bool>> filter)
        {
            return _context.Users
                .Where(filter)
                .Include(u => u.Address)
                .FirstOrDefault();
        }

        public override void Remove(ApplicationUser user)
        {
            //var userCart =
            //    _context.Carts
            //    .Where(c => c.CustomerId == user.Id)
            //    .FirstOrDefault();

            //var userProductSaves =
            //    _context.ProductSaves
            //    .Where(ps => ps.UserId == user.Id)
            //    .ToList();

            //var userProductReviews =
            //    _context.ProductsReviews
            //    .Where(pr => pr.CustomerId == user.Id)
            //    .ToList();

            //var userSales =
            //    _context.Sales
            //    .Where(s => s.CustomerId == user.Id)
            //    .ToList();

            //var userStoreSaves =
            //    _context.StoreSaves
            //    .Where(ss => ss.UserId == user.Id)
            //    .ToList();

            //var userStores =
            //    _context.Stores
            //    .Where(us => us.OwnerId == user.Id)
            //    .ToList();

            var storeSaves = new List<StoreSave>();

            var storeProducts = new List<Product>();

            //if (userCart != null)
            //{
            //    var productCart =
            //        _context.ProductsCarts
            //        .Where(pc => pc.Id == userCart.Id)
            //        .FirstOrDefault();

            //    if (productCart != null)
            //    {
            //        _context.ProductsCarts.Remove(productCart);
            //    }

            //    _context.Carts.Remove(userCart);
            //}

            //foreach (var saveItem in userProductSaves)
            //{
            //    _context.ProductSaves.Remove(saveItem);
            //}

            //foreach (var reviewItem in userProductReviews)
            //{
            //    _context.ProductsReviews.Remove(reviewItem);
            //}

            //foreach (var saleItem in userSales)
            //{
            //    _context.Sales.Remove(saleItem);
            //}

            //foreach (var saveItem in userStoreSaves)
            //{
            //    _context.StoreSaves.Remove(saveItem);
            //}

            //foreach (var store in userStores)
            //{
            //    storeSaves =
            //        _context.StoreSaves
            //        .Where(ss => ss.StoreId == store.Id)
            //        .ToList();

            //    storeProducts =
            //        _context.Products
            //        .Where(p => p.StoreId == store.Id)
            //        .ToList();

            //    foreach (var save in storeSaves)
            //    {
            //        _context.StoreSaves.Remove(save);
            //    }

            //    foreach (var product in storeProducts)
            //    {
            //        var productPhotos =
            //        _context.ProductPhotos
            //        .Where(pp => pp.ProductId == product.Id)
            //        .ToList();

            //        var productSaves =
            //            _context.ProductSaves
            //            .Where(ps => ps.ProductId == product.Id)
            //            .ToList();

            //        var productCarts =
            //            _context.ProductsCarts
            //            .Where(pc => pc.ProductId == product.Id)
            //            .ToList();

            //        var productReviews =
            //            _context.ProductsReviews
            //            .Where(pr => pr.ProductId == product.Id)
            //            .ToList();

            //        var productSales =
            //            _context.Sales
            //            .Where(s => s.ProductId == product.Id)
            //            .ToList();

            //        foreach (var photo in productPhotos)
            //        {
            //            _context.ProductPhotos.Remove(photo);
            //        }

            //        foreach (var save in productSaves)
            //        {
            //            _context.ProductSaves.Remove(save);
            //        }

            //        foreach (var cart in productCarts)
            //        {
            //            _context.ProductsCarts.Remove(cart);
            //        }

            //        foreach (var review in productReviews)
            //        {
            //            _context.ProductsReviews.Remove(review);
            //        }

            //        foreach (var sale in productSales)
            //        {
            //            _context.Sales.Remove(sale);
            //        }

            //        _context.Products.Remove(product);
            //    }

            //    _context.Stores.Remove(store);
            //}

            //_context.Users.Remove(user);
        }
    }
}
