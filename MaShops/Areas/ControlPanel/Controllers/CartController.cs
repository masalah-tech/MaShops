using MaShops.DataAccess.Data;
using MaShops.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MaShops.Areas.ControlPanel.Controllers
{
    [Area("ControlPanel")]
    public class CartController : Controller
    {
        private readonly AppDbContext _context;

        public CartController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var carts = 
                _context.ProductsCarts
                .Include(ps => ps.Product)
                .Include(ps => ps.Cart)
                .Include(ps => ps.Cart.Customer)
                .ToList();

            return View(carts);
        }

        public IActionResult CartProducts(int cartId)
        {
            var productsCarts =
                _context.ProductsCarts
                .ToList();

            var products =
                _context.Products
                .Include(p => p.Store)
                .Include(p => p.Category)
                .ToList();

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
