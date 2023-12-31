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
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
            : base(context) 
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Product product)
        {
            _context.Products.Update(product);
        }

        public override IEnumerable<Product> GetAll()
        {
            return _context.Products
                .Include(p => p.Store)
                .Include(p => p.Category)
                .ToList();
        }

        public override IEnumerable<Product> GetRange(Expression<Func<Product, bool>> filter)
        {
            return _context.Products
                .Where(filter)
                .Include(p => p.Store)
                .Include(p => p.Category)
                .ToList();
        }

        public override Product Get(Expression<Func<Product, bool>> filter)
        {
            return _context.Products
                .Where(filter)
                .Include(p => p.Category)
                .Include(p => p.Store)
                .FirstOrDefault();
        }

        public override void Remove(Product product)
        {
            var productPhotos =
                    _context.ProductPhotos
                    .Where(pp => pp.ProductId == product.Id)
                    .ToList();

            var productSaves =
                _context.ProductSaves
                .Where(ps => ps.ProductId == product.Id)
                .ToList();

            var productCarts =
                _context.ProductsCarts
                .Where(pc => pc.ProductId == product.Id)
                .ToList();

            var productReviews =
                _context.ProductsReviews
                .Where(pr => pr.ProductId == product.Id)
                .ToList();

            var productSales =
                _context.Sales
                .Where(s => s.ProductId == product.Id)
                .ToList();

            foreach (var photo in productPhotos)
            {
                _context.ProductPhotos.Remove(photo);
            }

            foreach (var save in productSaves)
            {
                _context.ProductSaves.Remove(save);
            }

            foreach (var cart in productCarts)
            {
                _context.ProductsCarts.Remove(cart);
            }

            foreach (var review in productReviews)
            {
                _context.ProductsReviews.Remove(review);
            }

            foreach (var sale in productSales)
            {
                _context.Sales.Remove(sale);
            }

            _context.Products.Remove(product);
        }
    }
}
