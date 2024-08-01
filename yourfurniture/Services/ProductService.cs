using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ProductService
{
    private readonly IMongoCollection<Product> _products;

    public ProductService(MongoDBContext context)
    {
        _products = context.Products;
    }

    public async Task<List<Product>> GetProductsAsync() =>
        await _products.Find(product => true).ToListAsync();

    public async Task<Product> GetProductByIdAsync(string id) =>
        await _products.Find(product => product.Id == id).FirstOrDefaultAsync();
}
