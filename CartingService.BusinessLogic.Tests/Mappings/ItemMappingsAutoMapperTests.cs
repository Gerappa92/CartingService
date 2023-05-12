using AutoFixture;
using AutoMapper;
using CartingService.BusinessLogic.Mappings;
using CartingService.BusinessLogic.Models;
using CartingService.DataAccess.Entities;
using FluentAssertions;

namespace CartingService.BusinessLogic.Tests.Mappings;

[TestFixture]
public class ItemMappingsAutoMapperTests
{
    private IMapper _mapper;
    private readonly Fixture _fixture = new();

    private Item GetItem() => _fixture.Create<Item>();
    private ItemDto GetItemDto() => _fixture.Create<ItemDto>();

    [OneTimeSetUp]
    public void Init()
    {
        var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile<ItemMappingsAutoMapper>());
        _mapper = mapperConfiguration.CreateMapper();
    }

    [Test]
    public void Map_FromDtoToEntity_PropertiesMatch()
    {
        // Arrange
        ItemDto itemDto = GetItemDto();

        // Act
        var result = _mapper.Map<Item>(itemDto);

        // Assert
        result.Id.Should().Be(itemDto.Id);
        result.Name.Should().Be(itemDto.Name);
        result.Price.Should().Be(itemDto.Price);
        result.Quantity.Should().Be(itemDto.Quantity);
        result.Image.Should().BeEquivalentTo(itemDto.Image);
        result.Image.Should().NotBe(itemDto.Image);
    }

    [Test]
    public void Map_FromEntityToDto_PropertiesMatch()
    {
        // Arrange
        Item item = GetItem();
        // Act
        var result = _mapper.Map<ItemDto>(item);

        // Assert
        result.Id.Should().Be(item.Id);
        result.Name.Should().Be(item.Name);
        result.Price.Should().Be(item.Price);
        result.Quantity.Should().Be(item.Quantity);
        result.Image.Should().BeEquivalentTo(item.Image);
        result.Image.Should().NotBe(item.Image);
    }
}