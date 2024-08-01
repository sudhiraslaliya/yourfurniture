using System.Collections.Generic;
using System.Linq;

public class ShoppingCart
{
    public List<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();

    public void AddToCart(string productId)
    {
        var item = Items.FirstOrDefault(i => i.ProductId == productId);
        if (item != null)
        {
            item.Quantity++;
        }
        else
        {
            Items.Add(new ShoppingCartItem { ProductId = productId, Quantity = 1 });
        }
    }

    public void RemoveFromCart(string productId)
    {
        var item = Items.FirstOrDefault(i => i.ProductId == productId);
        if (item != null)
        {
            Items.Remove(item);
        }
    }

    public void UpdateQuantity(string productId, int quantity)
    {
        var item = Items.FirstOrDefault(i => i.ProductId == productId);
        if (item != null)
        {
            item.Quantity = quantity;
        }
    }
}
