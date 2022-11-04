using CatalogService.Application.ApiModels;

namespace CatalogService.Application.Services.Categories;

public interface ICategoryService
{
    Task<CategoryDto> GetByIdAsync(Guid categoryId, CancellationToken cancellationToken = default);

    Task<IEnumerable<CategoryDto>> GetAllAsync(CancellationToken cancellationToken = default);

    Task UpdateAsync(CategoryDto category, CancellationToken cancellationToken = default);

    Task DeleteAsync(Guid categoryId, CancellationToken cancellationToken = default);

    Task AddAsync(CategoryDto category, CancellationToken cancellationToken = default);
}
