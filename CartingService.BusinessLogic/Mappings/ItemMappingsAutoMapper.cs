using AutoMapper;

namespace CartingService.BusinessLogic.Mappings;

public class ItemMappingsAutoMapper : Profile
{
    public ItemMappingsAutoMapper()
    {
        CreateMap<Item, ItemDto>();
        CreateMap<Image, ImageDto>();
        CreateMap<ItemDto, Item>();
        CreateMap<ImageDto, Image>();
    }
}