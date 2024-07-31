namespace YourFurniture.Models
{
    public class CategoryWithProducts
    {
        public Category Category { get; set; } = new Category();
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
