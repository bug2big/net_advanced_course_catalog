using CatalogService.Domain.Entities;

namespace CatalogService.Application.Services.Categories
{
    public interface ICategoryService
    {
        Task<Category> GetByIdAsync(Guid categoryId, CancellationToken cancellationToken = default);

        Task<IEnumerable<Category>> GetAllAsync(CancellationToken cancellationToken = default);

        Task UpdateAsync(Category category, CancellationToken cancellationToken = default);

        Task DeleteAsync(Category category, CancellationToken cancellationToken = default);

        Task AddAsync(Category category, CancellationToken cancellationToken = default);
    }
}
