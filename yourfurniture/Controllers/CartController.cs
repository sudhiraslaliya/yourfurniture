using Microsoft.AspNetCore.Mvc;
using YourFurniture.Models;
using YourFurniture.Data;
using MongoDB.Driver;

namespace YourFurniture.Controllers
{
    public class CartController : Controller
    {
        private readonly ShoppingCart _cart;
        private readonly MongoDbContext _context;

        public CartController(ShoppingCart cart, MongoDbContext context)
        {
            _cart = cart;
            _context = context;
        }

        [HttpPost]
        public IActionResult AddToCart(string productId, int quantity)
        {
            var product = _context.Products.Find(p => p.Id == productId).FirstOrDefault();
            if (product != null)
            {
                _cart.AddToCart(product, quantity);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RemoveFromCart(string productId)
        {
            _cart.RemoveFromCart(productId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AdjustQuantity(string productId, int quantity)
        {
            _cart.AdjustQuantity(productId, quantity);
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            return View(_cart);
        }
    }
}
