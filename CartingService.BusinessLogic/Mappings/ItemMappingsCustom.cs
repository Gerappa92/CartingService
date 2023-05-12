namespace CartingService.BusinessLogic.Mappings;

public static class ItemMappingsCustom
{
    #region From BLL into DAL

    public static Item Map(this ItemDto itemDto)
        => new()
        {
            Id = itemDto.Id,
            Name = itemDto.Name,
            Image = itemDto.Image?.Map(),
            Price = itemDto.Price,
            Quantity = itemDto.Quantity
        };

    public static Image Map(this ImageDto imageDto)
        => new(imageDto.Url, imageDto.AltText);

    #endregion

    #region From DAL into BLL

    public static IEnumerable<ItemDto> Map(this IEnumerable<Item> item)
        => item.Select(Map).ToArray();

    public static ItemDto Map(this Item item)
        => new()
        {
            Id = item.Id,
            Name = item.Name,
            Image = item.Image?.Map(),
            Price = item.Price,
            Quantity = item.Quantity
        };

    public static ImageDto Map(this Image image)
        => new(image.Url, image.AltText);

    #endregion
}