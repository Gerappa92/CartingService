using Riok.Mapperly.Abstractions;

namespace CartingService.BusinessLogic.Mappings;

[Mapper]
public static partial class PersonMappingsMapperly
{
    #region From DAL to BLL

    private static partial PersonSlimDto ToPersonSlimInternal(this Person person);

    public static PersonSlimDto ToPersonSlim(this Person person)
    {
        var dto = person.ToPersonSlimInternal();
        if (dto == null)
            return null;
        dto.FullName = $"{person.FirstName} {person.LastName}";
        return dto;
    }

    public static partial PersonFlatDto ToPersonFlat(this Person person);

    #endregion

    #region From BLL to DAL

    [MapProperty(
        new[]
        {
            nameof(PersonFlatDto.CorrespondenceStreet)
        },
        new[]
        {
            nameof(Person.Correspondence),
            nameof(Person.Correspondence.Street)
        })]
    [MapProperty(
        new[]
        {
            nameof(PersonFlatDto.CorrespondenceCity)
        },
        new[]
        {
            nameof(Person.Correspondence),
            nameof(Person.Correspondence.City)
        })]
    [MapProperty("CorrespondenceState", "Correspondence.State")]
    public static partial Person ToPerson(this PersonFlatDto person);

    #endregion
}