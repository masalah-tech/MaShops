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
    public class BannerRepository : Repository<Banner>, IBannerRepository
    {
        private readonly AppDbContext _context;

        public BannerRepository(AppDbContext context)
            : base(context)
        {
            _context = context;
        }

        public void Update(Banner banner)
        {
            _context.Banners.Update(banner);
        }

        public override IEnumerable<Banner> GetAll()
        {
            return _context.Banners
                .OrderByDescending(b => b.Status)
                .ToList();
        }
    }
}
