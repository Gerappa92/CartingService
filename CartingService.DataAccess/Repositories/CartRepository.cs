using CartingService.DataAccess.Entities;
using CartingService.DataAccess.Repositories;
using LiteDB;

namespace CartingService.DataAccess.Repositories;

public class CartRepository : ICartRepository
{
    private const string CollectionName = "Carts";

    public IEnumerable<Item> ListItems(Guid cartId)
    {
        // TODO: rid of hardcoded path
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

    public void RemoveItem(Guid cartId, int itemId)
    {
        using var db = new LiteDatabase(@"C:\Temp\MyData.db");
        var collection = db.GetCollection<Cart>(CollectionName);

        var cart = collection.FindById(cartId);
        cart.Items = cart.Items.Where(x => x.Id != itemId);
        collection.Update(cartId, cart);
    }
}