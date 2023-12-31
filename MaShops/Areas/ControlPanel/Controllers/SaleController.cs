using MaShops.DataAccess.Data;
using MaShops.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MaShops.Areas.ControlPanel.Controllers
{
    [Area("ControlPanel")]
    public class SaleController : Controller
    {
        private readonly ISaleRepository _saleRepository;

        public SaleController(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }
        public IActionResult Index()
        {
            var sales =
                _saleRepository.GetAll();

            return View(sales);
        }

        public IActionResult Details(int id)
        {
            var sale =
                _saleRepository.Get(s => s.Id == id);

            return View(sale);
        }

    }
}
