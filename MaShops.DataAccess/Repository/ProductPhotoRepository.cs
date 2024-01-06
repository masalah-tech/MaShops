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
    public class ProductPhotoRepository 
        : Repository<ProductPhoto>, IProductPhotoRepository
    {
        private readonly AppDbContext _context;

        public ProductPhotoRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(ProductPhoto productPhoto)
        {
            _context.ProductPhotos.Update(productPhoto);
        }
    }
}
