using AutoMapper;

namespace CartingService.BusinessLogic.Mappings;

public class PersonMappingsAutoMapper : Profile
{
    public PersonMappingsAutoMapper()
    {
        CreateMap<Person, PersonFlatDto>();
        CreateMap<Person, PersonSlimDto>()
            .ForMember(
                x => x.FullName,
                opt => opt.MapFrom((src, _, _) => $"{src.FirstName} {src.LastName}"));
        CreateMap<Contact, ContactDto>();
    }
}