namespace CartingService.BusinessLogic.Mappings;

public static class CartMappings
{
    #region From BLL into DAL

    public static DataAccess.Entities.Item Map(this Models.Item item)
        => new()
        {
            Id = item.Id,
            Name = item.Name,
            Image = item.Image?.Map(),
            Price = item.Price,
            Quantity = item.Quantity
        };

    public static DataAccess.ValueObjects.Image Map(this Models.Image image)
        => new(image.Url, image.AltText);

    #endregion

    #region From DAL into BLL

    public static IEnumerable<Models.Item> Map(this IEnumerable<DataAccess.Entities.Item> item)
        => item.Select(Map).ToArray();

    public static Models.Item Map(this DataAccess.Entities.Item item)
        => new()
        {
            Id = item.Id,
            Name = item.Name,
            Image = item.Image?.Map(),
            Price = item.Price,
            Quantity = item.Quantity
        };

    public static Models.Image Map(this DataAccess.ValueObjects.Image image)
        => new(image.Url, image.AltText);

    #endregion
}