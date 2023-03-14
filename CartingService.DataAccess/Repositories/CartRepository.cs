using CartingService.DataAccess.Entities;
using LiteDB;

namespace CartingService.DataAccess.Repositories;

public interface ICartRepository
{
    IEnumerable<Item> ListItems(Guid cartId);
    void AddItem(Guid cartId, Item item);
    void RemoveItem(Guid cartId, Guid itemId);
}

public class CartRepository : ICartRepository
{
    private const string CollectionName = "Carts";

    public IEnumerable<Item> ListItems(Guid cartId)
    {
        using var db = new LiteDatabase(@"C:\Temp\MyData.db");
        var collection = db.GetCollection<Cart>(CollectionName);

        var cart = collection.FindById(cartId);
        return cart.Items.ToArray();
    }

    public void AddItem(Guid cartId, Item item)
    {
        using var db = new LiteDatabase(@"C:\Temp\MyData.db");
        var collection = db.GetCollection<Cart>(CollectionName);

        var cart = collection.FindById(cartId);
        cart.Items.ToList().Add(item);
        collection.Upsert(cartId, cart);
    }

    public void RemoveItem(Guid cartId, Guid itemId)
    {
        using var db = new LiteDatabase(@"C:\Temp\MyData.db");
        var collection = db.GetCollection<Cart>(CollectionName);

        var cart = collection.FindById(cartId);
        cart.Items = cart.Items.Where(x => x.Id != itemId);
        collection.Update(cartId, cart);
    }
}