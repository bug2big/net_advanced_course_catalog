using net_advanced_course.DAL.Entities;

namespace net_advanced_course.BLL.Services.Categories
{
    public interface ICategoryService
    {
        Category GetById(Guid categoryId);

        IEnumerable<Category> GetAll();

        void Upsert(Category category);

        void Delete(Category category);
    }
}
