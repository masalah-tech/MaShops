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
    public class SaleRepository : Repository<Sale>, ISaleRepository
    {
        private readonly AppDbContext _context;

        public SaleRepository(AppDbContext context)
            : base(context)
        {
            _context = context;
        }
        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Sale sale)
        {
            _context.Sales.Update(sale);
        }

        public override IEnumerable<Sale> GetAll()
        {
            return _context.Sales
                .Include(s => s.Customer)
                .Include(s => s.Product)
                .Include(s => s.Product.Store)
                .OrderByDescending(s => s.DateTime)
                .ToList();
        }

        public override Sale Get(Expression<Func<Sale, bool>> filter)
        {
            return _context.Sales
                .Where(filter)
                .Include(s => s.Customer)
                .Include(s => s.Product)
                .Include(s => s.Product.Store)
                .Include(s => s.Product.Category)
                .FirstOrDefault();
        }
    }
}
