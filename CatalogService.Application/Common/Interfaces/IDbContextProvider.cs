using CatalogService.Domain.Common;

namespace CatalogService.Application.Common.Interfaces
{
    public interface IDbContextProvider<TEntity> where TEntity : BaseEntity
    {
        DbSet<TEntity> DbSet { get; }

        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

        Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);

        Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    }
}
