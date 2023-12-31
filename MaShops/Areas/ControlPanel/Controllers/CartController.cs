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
        private readonly IProductCartRepository _productCartRepository;
        private readonly IProductRepository _productRepository;

        public CartController(IProductCartRepository productCartRepository,
            IProductRepository productRepository)
        {
            _productCartRepository = productCartRepository;
            _productRepository = productRepository;
        }
        public IActionResult Index()
        {
            var carts =
                _productCartRepository.GetAll();

            return View(carts);
        }

        public IActionResult CartProducts(int cartId)
        {
            var productsCarts =
                _productCartRepository.GetAll();

            var products =
                _productRepository.GetAll();

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
