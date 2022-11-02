using net_advanced_course.DAL.Entities;

namespace net_advanced_course.DAL.Repositories.Categories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(SqlDbContext sqlDbContext)
            : base(sqlDbContext)
        {
        }
    }
}
