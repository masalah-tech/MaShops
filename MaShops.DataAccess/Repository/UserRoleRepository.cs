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
    public class UserRoleRepository : Repository<UserRole>, IUserRoleRepository
    {
        private readonly AppDbContext _context;

        public UserRoleRepository(AppDbContext context)
            : base(context)
        {
            _context = context;
        }

        public void Update(UserRole userRole)
        {
            _context.UsersRoles.Update(userRole);
        }

        public override UserRole Get(Expression<Func<UserRole, bool>> filter)
        {
            return _context.UsersRoles
                .Where(filter)
                .Include(ur => ur.Role)
                .FirstOrDefault();
        }

        public override IEnumerable<UserRole> GetRange(Expression<Func<UserRole, bool>> filter)
        {
            return _context.UsersRoles
                .Where(filter)
                .Include(ur => ur.Role)
                .ToList();
        }
    }
}
