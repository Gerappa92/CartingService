﻿namespace CartingService.BusinessLogic.Models;

public class Item
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Image Image { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}