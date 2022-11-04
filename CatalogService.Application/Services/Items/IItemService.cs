using CatalogService.Application.ApiModels;

namespace CatalogService.Application.Services.Items;
public interface IItemService
{
    Task<ItemDto> GetByIdAsync(Guid itemId, CancellationToken cancellationToken = default);

    Task<IEnumerable<ItemDto>> GetAllAsync(CancellationToken cancellationToken = default);

    Task UpdateAsync(ItemDto item, CancellationToken cancellationToken = default);

    Task DeleteAsync(Guid itemId, CancellationToken cancellationToken = default);

    Task AddAsync(ItemDto item, CancellationToken cancellationToken = default);
}
