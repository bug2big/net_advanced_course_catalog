using CatalogService.Application.Common;
using CatalogService.Domain.Common;

namespace CatalogService.Infrastructure.Persistence
{
    public class ApplicationDbContext<TEntity> : DbContext, IApplicationDbContext<TEntity> where TEntity : BaseEntity
    {
        public DbSet<TEntity> Entities { get; set; }

        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
            Entities = Set<TEntity>();
        }

        public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            base.Update(entity);
            await base.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            base.Remove(entity);
            await base.SaveChangesAsync(cancellationToken);
        }

        public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await base.AddAsync(entity, cancellationToken);
            await base.SaveChangesAsync(cancellationToken);
        }
    }
}
