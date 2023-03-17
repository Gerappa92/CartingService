using CartingService.DataAccess.Entities;

namespace CartingService.DataAccess.Repositories;

public interface ICartRepository
{
    IEnumerable<Item> ListItems(Guid cartId);
    void AddItem(Guid cartId, Item item);
    void RemoveItem(Guid cartId, int itemId);
}