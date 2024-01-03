using MaShops.DataAccess.Data;
using MaShops.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaShops.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public IBannerRepository BannerRepository { get; private set; }

        public ICartRepository CartRepository { get; private set; }

        public ICategoryRepository CategoryRepository { get; private set; }

        public IProductCartRepository ProductCartRepository { get; private set; }

        public IProductRepository ProductRepository { get; private set; }

        public ISaleRepository SaleRepository { get; private set; }

        public IStoreRepository StoreRepository { get; private set; }

        public IUserRepository UserRepository { get; private set; }
        public IRoleRepository RoleRepository { get; private set; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            BannerRepository = new BannerRepository(_context);
            CartRepository = new CartRepository(_context);
            CategoryRepository = new CategoryRepository(_context);
            ProductCartRepository = new ProductCartRepository(_context);
            ProductRepository = new ProductRepository(_context);
            SaleRepository = new SaleRepository(_context);
            StoreRepository = new StoreRepository(_context);
            UserRepository = new UserRepository(_context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
