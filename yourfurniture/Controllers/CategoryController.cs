using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using YourFurniture.Data; 
using YourFurniture.Models;  

namespace YourFurniture.Controllers  // Add namespace
{
    public class CategoryController : Controller
    {
        private readonly MongoDbContext _context;

        public CategoryController(MongoDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var categories = _context.Categories.Find(_ => true).ToList();
            return View(categories);
        }

        public IActionResult Details(string id)
        {
            var category = _context.Categories.Find(c => c.Id == id).FirstOrDefault();
            var products = _context.Products.Find(p => p.CategoryId == id).ToList();

            var viewModel = new CategoryWithProducts
            {
                Category = category,
                Products = products
            };

            return View(viewModel);
        }
    }

    internal class CategoryWithProducts
    {
        public Category ?Category { get; set; }
        public List<Product> ?Products { get; set; }
    }
}
