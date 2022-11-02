using net_advanced_course.BLL.Services.Categories;
using net_advanced_course.BLL.Services.Items;
using net_advanced_course.DAL.Repositories.Categories;
using net_advanced_course.DAL.Repositories.Items;

namespace net_advanced_course.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IItemService, ItemService>();
            services.AddTransient<ICategoryService, CategoryService>();

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IItemRepository, ItemRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();

            return services;
        }
    }
}
