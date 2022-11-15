using CatalogService.Application.ApiModels;
using CatalogService.Domain.Entities;

namespace CatalogService.Domain.Common.Mappings;

public class MapperConfiguration : Profile
{
    public MapperConfiguration()
    {
        CategoryMapping();
        ItemMapping();
    }

    private void CategoryMapping()
    {
        CreateMap<Category, CategoryDto>()
            .ReverseMap();
    }

    private void ItemMapping()
    {
        CreateMap<Item, ItemDto>()
            .ReverseMap();
    }
}
