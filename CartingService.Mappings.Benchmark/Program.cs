using AutoFixture;
using AutoMapper;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using CartingService.BusinessLogic.Mappings;
using CartingService.BusinessLogic.Models;
using CartingService.DataAccess.Entities;

BenchmarkRunner.Run<MappingTests>();

public class MappingTests
{

    private readonly Fixture _fixture = new();
    private Person _person;

    private IMapper _mapper;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
            .ForEach(b => _fixture.Behaviors.Remove(b));
        _fixture.Behaviors.Add(new OmitOnRecursionBehavior());

        _person = GetPerson();

        _mapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<PersonMappingsAutoMapper>();
        }).CreateMapper();
    }

    private Person GetSpouse() => _fixture.Create<Person>();
    private List<Person> Children() => _fixture.CreateMany<Person>(3).ToList();

    private Person GetPerson() => _fixture.Build<Person>()
        .With(x => x.Spouse, GetSpouse())
        .With(x => x.Children, Children())
        .Create();

    [Benchmark]
    public PersonFlatDto Mapperly() => _person.ToPersonFlat();

    [Benchmark]
    public PersonFlatDto AutoMapper() => _mapper.Map<PersonFlatDto>(_person);
}
