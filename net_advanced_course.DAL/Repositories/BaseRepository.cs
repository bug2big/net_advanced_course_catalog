using Microsoft.EntityFrameworkCore;
using net_advanced_course.DAL.Entities;

namespace net_advanced_course.DAL.Repositories
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity>
        where TEntity : BaseEntity
    {
        private readonly SqlDbContext _sqlDbContext;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseRepository(SqlDbContext sqlDbContext)
        {
            _sqlDbContext = sqlDbContext;
            _sqlDbContext.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbSet.ToList().AsQueryable();
        }

        public TEntity GetById(Guid entityId)
        {
            return _dbSet.FirstOrDefault(t => t.Id == entityId);
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
            _sqlDbContext.SaveChanges();
        }

        public void Upsert(TEntity entity)
        {
            if (GetById(entity.Id) == null)
            {
                _dbSet.Add(entity);
            }
            else
            {
                _dbSet.Update(entity);
            }
            _sqlDbContext.SaveChanges();
        }
    }
}
