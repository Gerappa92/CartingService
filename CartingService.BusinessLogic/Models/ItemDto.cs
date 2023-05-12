namespace CartingService.BusinessLogic.Models;

public class ItemDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ImageDto Image { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}