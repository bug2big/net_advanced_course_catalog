using CatalogService.Application.Common;
using CatalogService.Application.Common.Exceptions;
using CatalogService.Domain.Entities;

namespace CatalogService.Application.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly IApplicationDbContext<Category> _applicationDbContext;

        public CategoryService(IApplicationDbContext<Category> applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Category> GetByIdAsync(Guid categoryId, CancellationToken cancellationToken = default)
        {
            var entity = await _applicationDbContext
                    .Entities
                    .FirstOrDefaultAsync(c => c.Id == categoryId, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Category), categoryId);
            }

            return entity;
        }

        public async Task<IEnumerable<Category>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _applicationDbContext.Entities.ToListAsync(cancellationToken);
        }

        public async Task UpdateAsync(Category category, CancellationToken cancellationToken = default)
        {
            await _applicationDbContext.UpdateAsync(category, cancellationToken);
        }

        public async Task DeleteAsync(Category category, CancellationToken cancellationToken = default)
        {
            await _applicationDbContext.DeleteAsync(category, cancellationToken);
        }

        public async Task AddAsync(Category category, CancellationToken cancellationToken = default)
        {
            await _applicationDbContext.AddAsync(category, cancellationToken);
        }
    }
}
