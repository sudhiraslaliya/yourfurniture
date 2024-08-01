using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

public class CategoryService
{
    private readonly IMongoCollection<Category> _categories;

    public CategoryService(MongoDBContext context)
    {
        _categories = context.Categories;
    }

    public async Task<List<Category>> GetCategoriesAsync() =>
        await _categories.Find(category => true).ToListAsync();
}
