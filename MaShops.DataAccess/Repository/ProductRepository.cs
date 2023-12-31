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
    }
}
