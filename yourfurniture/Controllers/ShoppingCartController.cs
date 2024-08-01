using Microsoft.AspNetCore.Mvc;


namespace yourfurniture.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ProductService _productService;
        private ShoppingCart _shoppingCart;

        public ShoppingCartController(ProductService productService)
        {
            _productService = productService;
            _shoppingCart = new ShoppingCart();
        }

        public IActionResult Index()
        {
            return View(_shoppingCart);
        }

        public async Task<IActionResult> AddToCart(string productId)
        {
            var product = await _productService.GetProductByIdAsync(productId);
            if (product == null)
            {
                return NotFound();
            }

            _shoppingCart.AddToCart(productId);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult RemoveFromCart(string productId)
        {
            _shoppingCart.RemoveFromCart(productId);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult UpdateQuantity(string productId, int quantity)
        {
            _shoppingCart.UpdateQuantity(productId, quantity);
            return RedirectToAction(nameof(Index));
        }
    }
}
