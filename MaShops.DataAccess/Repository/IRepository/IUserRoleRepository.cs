using MaShops.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaShops.DataAccess.Repository.IRepository
{
    public interface IUserRoleRepository : IRepository<UserRole>
    {
        void Update(UserRole userRole);
    }
}
