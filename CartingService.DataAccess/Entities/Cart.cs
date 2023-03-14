namespace CartingService.DataAccess.Entities;

public class Cart
{
    public Guid Id { get; set; }
    public IEnumerable<Item> Items { get; set; }
}