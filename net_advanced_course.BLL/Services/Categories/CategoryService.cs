using net_advanced_course.DAL.Entities;
using net_advanced_course.DAL.Repositories.Categories;

namespace net_advanced_course.BLL.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Category GetById(Guid categoryId)
        {
            return _categoryRepository.GetById(categoryId);
        }

        public IEnumerable<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public void Upsert(Category category)
        {
            _categoryRepository.Upsert(category);
        }

        public void Delete(Category category)
        {
            _categoryRepository.Delete(category);
        }
    }
}
