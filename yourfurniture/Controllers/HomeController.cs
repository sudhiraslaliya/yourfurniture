using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using YourFurniture.Data;
using YourFurniture.Models;

namespace YourFurniture.Controllers
{
    public class HomeController : Controller
    {
        private readonly MongoDbContext _context;

        public HomeController(MongoDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var categories = _context.Categories.Find(_ => true).ToList();
            var featuredProducts = _context.Products.Find(_ => true).Limit(5).ToList();

            var viewModel = new HomeView
            {
                Categories = categories,
                FeaturedProducts = featuredProducts
            };

            return View(viewModel);
        }
    }

    internal class HomeView
    {
        public List<Category>? Categories { get; set; }
        public List<Product>? FeaturedProducts { get; set; }
    }
}


