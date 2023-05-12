using Riok.Mapperly.Abstractions;

namespace CartingService.BusinessLogic.Mappings;

[Mapper]
public static partial class ItemMappingsMapperly
{
    #region From BLL into DAL

    public static partial Item MapperlyMap(this ItemDto itemDto);

    #endregion

    #region From DAL into BLL

    public static partial ItemDto MapperlyMap(this Item itemDto);

    #endregion
}