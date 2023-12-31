using MaShops.DataAccess.Data;
using MaShops.DataAccess.Repository.IRepository;
using MaShops.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MaShops.DataAccess.Repository
{
    public class StoreRepository : Repository<Store>, IStoreRepository
    {
        private readonly AppDbContext _context;

        public StoreRepository(AppDbContext context)
            : base(context) 
        {
            _context = context;
        }
        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Store store)
        {
            _context.Stores.Update(store);
        }

        public override IEnumerable<Store> GetAll()
        {
            return _context.Stores
                .Include(s => s.Owner)
                .ToList();
        }

        public override Store Get(Expression<Func<Store, bool>> filter)
        {
            return _context.Stores
                .Where(filter)
                .Include(s => s.Owner)
                .FirstOrDefault();
        }

        public override void Remove(Store store)
        {
            var storeProducts =
                _context.Products
                .Where(p => p.StoreId == store.Id)
                .ToList();

            var storeSaves =
                _context.StoreSaves
                .Where(ss => ss.StoreId == store.Id)
                .ToList();

            var productPhotos = new List<ProductPhoto>();
            var productSaves = new List<ProductSave>();
            var productCarts = new List<ProductCart>();
            var productReviews = new List<ProductReview>();
            var productSales = new List<Sale>();

            foreach (var product in storeProducts)
            {
                productPhotos =
                    _context.ProductPhotos
                    .Where(pp => pp.ProductId == product.Id)
                    .ToList();

                foreach (var photo in productPhotos)
                {
                    _context.ProductPhotos.Remove(photo);
                }

                productSaves =
                    _context.ProductSaves
                    .Where(ps => ps.ProductId == product.Id)
                    .ToList();

                foreach (var save in productSaves)
                {
                    _context.ProductSaves.Remove(save);
                }

                productCarts =
                    _context.ProductsCarts
                    .Where(pc => pc.ProductId == product.Id)
                    .ToList();

                foreach (var cart in productCarts)
                {
                    _context.ProductsCarts.Remove(cart);
                }

                productReviews =
                    _context.ProductsReviews
                    .Where(pr => pr.ProductId == product.Id)
                    .ToList();

                foreach (var review in productReviews)
                {
                    _context.ProductsReviews.Remove(review);
                }

                productSales =
                    _context.Sales
                    .Where(s => s.ProductId == product.Id)
                    .ToList();

                foreach (var sale in productSales)
                {
                    _context.Sales.Remove(sale);
                }

                _context.Products.Remove(product);
            }

            foreach (var save in storeSaves)
            {
                _context.StoreSaves.Remove(save);
            }

            _context.Stores.Remove(store);
        }
    }
}
