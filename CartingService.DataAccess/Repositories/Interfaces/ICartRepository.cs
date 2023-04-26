using CartingService.DataAccess.Entities;

namespace CartingService.DataAccess.Repositories;

public interface ICartRepository
{
    IEnumerable<Item> ListItems(Guid cartId);
    void AddItem(Guid cartId, Item item);
    int UpdateItem(int id, string name, decimal price);
    bool RemoveItem(Guid cartId, int itemId);
}