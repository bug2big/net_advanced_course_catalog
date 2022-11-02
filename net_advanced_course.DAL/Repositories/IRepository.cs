namespace net_advanced_course.DAL.Repositories
{
    public interface IRepository<TEntity>
    {
        IQueryable<TEntity> GetAll();

        TEntity GetById(Guid entityId);

        void Delete(TEntity entity);

        void Upsert(TEntity entity);
    }
}
