using MaShops.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaShops.DataAccess.Repository.IRepository
{
    public interface IBannerRepository : IRepository<Banner>
    {
        void Update(Banner banner);
    }
}
