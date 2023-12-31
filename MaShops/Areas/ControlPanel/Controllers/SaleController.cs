using MaShops.DataAccess.Data;
using MaShops.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MaShops.Areas.ControlPanel.Controllers
{
    [Area("ControlPanel")]
    public class SaleController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public SaleController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var sales =
                _unitOfWork.SaleRepository
                .GetAll();

            return View(sales);
        }

        public IActionResult Details(int id)
        {
            var sale =
                _unitOfWork.SaleRepository
                .Get(s => s.Id == id);

            return View(sale);
        }

    }
}
