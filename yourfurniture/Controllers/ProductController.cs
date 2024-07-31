using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using YourFurniture.Models;
using YourFurniture.Data;

namespace YourFurniture.Controllers
{
    public class ProductController : Controller
    {
        private readonly MongoDbContext _context;

        public ProductController(MongoDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var products = _context.Products.Find(_ => true).ToList();
            return View(products);
        }

        public IActionResult Details(string id)
        {
            var product = _context.Products.Find(p => p.Id == id).FirstOrDefault();
            return View(product);
        }
    }
}
