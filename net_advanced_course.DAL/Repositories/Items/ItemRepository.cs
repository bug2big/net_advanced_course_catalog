using net_advanced_course.DAL.Entities;

namespace net_advanced_course.DAL.Repositories.Items
{
    public class ItemRepository : BaseRepository<Item>, IItemRepository
    {
        public ItemRepository(SqlDbContext sqlDbContext)
            : base(sqlDbContext)
        {
        }
    }
}
