using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using YourFurniture.Models;

namespace YourFurniture.Controllers
{
    public class HomeController : Controller
    {
        private readonly MongoDBContext _context;

        public HomeController(MongoDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var categories = _context.Categories.Find(_ => true).ToList();
            var featuredProducts = _context.Products.Find(_ => true).Limit(5).ToList();

            var viewModel = new HomeViewModel
            {
                Categories = categories,
                FeaturedProducts = featuredProducts
            };

            return View(viewModel);
        }
    }

    
}
