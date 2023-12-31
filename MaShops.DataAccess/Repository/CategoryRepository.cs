using MaShops.DataAccess.Data;
using MaShops.DataAccess.Repository.IRepository;
using MaShops.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaShops.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category> ,ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
            : base(context)
        {
            _context = context;
        }

        public void Update(Category category)
        {
            _context.Categories.Update(category);
        }

        public override void Remove(Category category)
        {
            var categoryProducts =
                _context.Products
                .Where(p => p.CategoryId == category.Id)
                .ToList();

            var productPhotos = new List<ProductPhoto>();
            var productSaves = new List<ProductSave>();
            var productCarts = new List<ProductCart>();
            var productReviews = new List<ProductReview>();
            var productSales = new List<Sale>();

            foreach (var product in categoryProducts) 
            {
                productPhotos =
                    _context.ProductPhotos
                    .Where(pp => pp.ProductId == product.Id)
                    .ToList();

                productSaves =
                    _context.ProductSaves
                    .Where(ps => ps.ProductId == product.Id)
                    .ToList();

                productCarts =
                    _context.ProductsCarts
                    .Where(pc => pc.ProductId == product.Id)
                    .ToList();

                productReviews =
                    _context.ProductsReviews
                    .Where(pr => pr.ProductId == product.Id)
                    .ToList();

                productSales =
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

            _context.Categories.Remove(category);
        }
    }
}
