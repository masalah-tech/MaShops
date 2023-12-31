using MaShops.DataAccess.Data;
using MaShops.DataAccess.Repository.IRepository;
using MaShops.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MaShops.Areas.ControlPanel.Controllers
{
    [Area("ControlPanel")]
    public class CartController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CartController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var carts =
                _unitOfWork.ProductCartRepository.GetAll();

            return View(carts);
        }

        public IActionResult CartProducts(int cartId)
        {
            var productsCarts =
                _unitOfWork.ProductCartRepository.GetAll();

            var products =
                _unitOfWork.ProductRepository.GetAll();

            var cartProducts = new List<Product>();

            foreach (var product in products)
            {
                foreach (var productCart in productsCarts)
                {
                    if (productCart.ProductId == product.Id
                        && productCart.CartId == cartId)
                    {
                        cartProducts.Add(product);
                    }
                }
            }

            return View(cartProducts);
        }
    }
}
