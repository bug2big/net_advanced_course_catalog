using net_advanced_course.DAL.Entities;
using net_advanced_course.DAL.Repositories.Items;

namespace net_advanced_course.BLL.Services.Items
{
    public interface IItemService
    {
        Item GetById(Guid itemId);

        IEnumerable<Item> GetAll();

        void Upsert(Item item);

        void Delete(Item item);
    }
}
