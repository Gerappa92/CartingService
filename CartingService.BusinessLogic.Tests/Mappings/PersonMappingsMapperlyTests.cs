using AutoFixture;
using CartingService.BusinessLogic.Mappings;
using CartingService.DataAccess.Entities;
using FluentAssertions;

namespace CartingService.BusinessLogic.Tests.Mappings;

[TestFixture]
public class PersonMappingsMapperlyTests
{
    private readonly Fixture _fixture = new();

    private Person GetSpouse() => _fixture.Create<Person>();
    private List<Person> Children() => _fixture.CreateMany<Person>(3).ToList();

    private Person GetPerson() => _fixture.Build<Person>()
        .With(x => x.Spouse, GetSpouse())
        .With(x => x.Children, Children())
        .Create();

    [OneTimeSetUp]
    public void Init()
    {
        _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
            .ForEach(b => _fixture.Behaviors.Remove(b));
        _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
    }
    [Test]
    public void ToPersonSlim_FromEntityToDto_PropertiesMatch()
    {
        // Arrange
        Person person = GetPerson();

        // Act
        var result = person.ToPersonSlim();

        // Assert
        result.Should().NotBeNull();
        result.FullName.Should().Be($"{person.FirstName} {person.LastName}");
        result.Age.Should().Be(person.Age);
        result.Employer.Should().Be(person.Employer);
        result.Occupation.Should().Be(person.Occupation);
    }

    [Test]
    public void ToPersonFlat_FromEntityToDto_PropertiesMatch()
    {
        // Arrange
        Person person = GetPerson();

        // Act
        var result = person.ToPersonFlat();

        // Assert
        result.Should().NotBeNull();
        result.FirstName.Should().Be(person.FirstName);
        result.LastName.Should().Be(person.LastName);
        result.Age.Should().Be(person.Age);
        result.DateOfBirth.Should().Be(person.DateOfBirth);
        result.Nationality.Should().Be(person.Nationality);
        result.Occupation.Should().Be(person.Occupation);
        result.Employer.Should().Be(person.Employer);
        result.EducationLevel.Should().Be(person.EducationLevel);
        result.Income.Should().Be(person.Income);
        result.MaritalStatus.Should().Be(person.MaritalStatus);
        result.Spouse.Should().BeEquivalentTo(person.Spouse);
        result.Children.Should().BeEquivalentTo(person.Children);
        result.CorrespondenceStreet.Should().Be(person.Correspondence.Street);
        result.CorrespondenceCity.Should().Be(person.Correspondence.City);
        result.CorrespondenceState.Should().Be(person.Correspondence.State);
        result.CorrespondenceZipCode.Should().Be(person.Correspondence.ZipCode);
        result.CorrespondenceContacts.Should().BeEquivalentTo(person.Correspondence.Contacts);
    }
}