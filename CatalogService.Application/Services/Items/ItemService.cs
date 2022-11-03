using CatalogService.Application.Common;
using CatalogService.Application.Common.Exceptions;
using CatalogService.Domain.Entities;

namespace CatalogService.Application.Services.Items
{
    public class ItemService : IItemService
    {
        private readonly IApplicationDbContext<Item> _applicationDbContext;

        public ItemService(IApplicationDbContext<Item> applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Item> GetByIdAsync(Guid itemId, CancellationToken cancellationToken = default)
        {
            var entity =  await _applicationDbContext
                .Entities
                .FirstOrDefaultAsync(i => i.Id == itemId, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Item), itemId);
            }

            return entity;
        }

        public async Task<IEnumerable<Item>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _applicationDbContext.Entities.ToListAsync(cancellationToken);
        }

        public async Task UpdateAsync(Item item, CancellationToken cancellationToken = default)
        {
            await _applicationDbContext.UpdateAsync(item, cancellationToken);
        }

        public async Task DeleteAsync(Item item, CancellationToken cancellationToken = default)
        {
            await _applicationDbContext.DeleteAsync(item, cancellationToken);
        }

        public async Task AddAsync(Item item, CancellationToken cancellationToken = default)
        {
            await _applicationDbContext.AddAsync(item, cancellationToken);
        }
    }
}
