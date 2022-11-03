using CatalogService.Domain.Common;

namespace CatalogService.Application.Common
{
    public interface IApplicationDbContext<TEntity> where TEntity : BaseEntity
    {
        DbSet<TEntity> Entities { get; set; }

        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

        Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);

        Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    }
}
