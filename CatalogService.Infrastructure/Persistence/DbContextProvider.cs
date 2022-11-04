using CatalogService.Application.Common.Interfaces;
using CatalogService.Domain.Common;

namespace CatalogService.Infrastructure.Persistence
{
    public class DbContextProvider<TEntity> : IDbContextProvider<TEntity> where TEntity : BaseEntity
    {
        private ApplicationDbContext _context;

        public DbSet<TEntity> DbSet { get; }

        public DbContextProvider(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
            DbSet = _context.Set<TEntity>();
        }

        public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            DbSet.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            DbSet.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await DbSet.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
