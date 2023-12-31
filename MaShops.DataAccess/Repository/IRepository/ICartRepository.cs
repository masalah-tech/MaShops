using MaShops.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaShops.DataAccess.Repository.IRepository
{
    public interface ICartRepository : IRepository<Cart>
    {
        void Update(Cart cart);
        void Save();
    }
}
