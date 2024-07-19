using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaShops.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IBannerRepository BannerRepository { get; }
        ICartRepository CartRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IProductCartRepository ProductCartRepository { get; }
        IProductRepository ProductRepository { get; }
        ISaleRepository SaleRepository { get; }
        IStoreRepository StoreRepository { get; }
        IUserRepository UserRepository { get; }
        IProductPhotoRepository ProductPhotoRepository { get; }
        void Save();
    }
}
