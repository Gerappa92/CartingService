namespace CartingService.BusinessLogic.Models;

public class Cart
{
    public Guid Id { get; set; }
    public IEnumerable<Item> Items { get; set; }
}