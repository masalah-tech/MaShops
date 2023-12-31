using MaShops.DataAccess.Data;
using MaShops.DataAccess.Repository.IRepository;
using MaShops.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaShops.DataAccess.Repository
{
    public class ProductCartRepository
        : Repository<ProductCart>, IProductCartRepository
    {
        private readonly AppDbContext _context;

        public ProductCartRepository(AppDbContext context)
            : base(context)
        {
            _context = context;
        }

        public void Update(ProductCart productCart)
        {
            _context.ProductsCarts.Update(productCart);
        }

        public override IEnumerable<ProductCart> GetAll()
        {
            return 
                _context.ProductsCarts
                .Include(ps => ps.Product)
                .Include(ps => ps.Cart)
                .Include(ps => ps.Cart.Customer)
                .ToList();
        }
    }
}
