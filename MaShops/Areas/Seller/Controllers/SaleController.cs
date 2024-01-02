using MaShops.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace MaShops.Areas.Seller.Controllers
{
    [Area("Seller")]
    public class SaleController : Controller
    {
        private readonly int _sellerId;
        private readonly IUnitOfWork _unitOfWork;

        public SaleController(IUnitOfWork unitOfWork)
        {
            _sellerId = 6;
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var sales =
                _unitOfWork.SaleRepository
                .GetRange(s => s.Product.Store.OwnerId == _sellerId);

            return View(sales);
        }

        public IActionResult Details(int id) 
        { 
            var sale =
                _unitOfWork.SaleRepository
                .Get(s => s.Id == id);

            if (sale == null)
            {
                return NotFound();
            }

            return View(sale);
        }
    }
}
