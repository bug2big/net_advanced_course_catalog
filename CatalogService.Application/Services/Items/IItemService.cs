using CatalogService.Domain.Entities;

namespace CatalogService.Application.Services.Items
{
    public interface IItemService
    {
        Task<Item> GetByIdAsync(Guid itemId, CancellationToken cancellationToken = default);

        Task<IEnumerable<Item>> GetAllAsync(CancellationToken cancellationToken = default);

        Task UpdateAsync(Item category, CancellationToken cancellationToken = default);

        Task DeleteAsync(Item category, CancellationToken cancellationToken = default);

        Task AddAsync(Item category, CancellationToken cancellationToken = default);
    }
}
