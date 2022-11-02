using net_advanced_course.DAL.Entities;
using net_advanced_course.DAL.Repositories.Items;

namespace net_advanced_course.BLL.Services.Items
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public Item GetById(Guid itemId)
        {
            return _itemRepository.GetById(itemId);
        }

        public IEnumerable<Item> GetAll()
        {
            return _itemRepository.GetAll();
        }

        public void Upsert(Item item)
        {
            _itemRepository.Upsert(item);
        }

        public void Delete(Item item)
        {
            _itemRepository.Delete(item);
        }
    }
}
