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

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Category category)
        {
            _context.Categories.Update(category);
        }
    }
}
