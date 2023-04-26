using CartingService.DataAccess.Entities;
using CartingService.DataAccess.Options;
using Microsoft.Extensions.Options;

namespace CartingService.DataAccess.Repositories;

public class CartRepository : BaseRepository, ICartRepository
{
    private const string CollectionName = "Carts";

    public CartRepository(IOptions<DataAccessOptions> options) : base(options)
    {
    }

    public IEnumerable<Item> ListItems(Guid cartId)
    {
        using var db = GetDatabase();
        var collection = db.GetCollection<Cart>(CollectionName);

        var cart = collection.FindById(cartId);
        return cart?.Items.ToArray();
    }

    public int UpdateItem(int id, string name, decimal price)
    {
        using var db = GetDatabase();
        var collection = db.GetCollection<Cart>(CollectionName);

        var carts = collection.Find(p => p.Items.Select(i=> i.Id).Any(i => i == id)).ToArray();

        foreach (var cart in carts)
        {
            foreach (var cartItem in cart.Items.Where(i => i.Id == id))
            {
                cartItem.Name = name;
                cartItem.Price = price;
            }
            collection.Update(cart.Id, cart);
        }

        return carts.Count();
    }

    public void AddItem(Guid cartId, Item item)
    {
        using var db = GetDatabase();
        var collection = db.GetCollection<Cart>(CollectionName);

        var cart = collection.FindById(cartId) ?? new Cart { Id = cartId };
        cart.Items = cart.Items.Append(item);

        collection.Upsert(cartId, cart);
    }

    public bool RemoveItem(Guid cartId, int itemId)
    {
        using var db = GetDatabase();
        var collection = db.GetCollection<Cart>(CollectionName);

        var cart = collection.FindById(cartId);
        if (cart is null || cart.Items.All(x => x.Id != itemId))
        {
            return false;
        }

        cart.Items = cart.Items.Where(x => x.Id != itemId);
        return collection.Update(cartId, cart);
    }
}