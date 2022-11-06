using CatalogService.Application.Services.Categories;
using CatalogService.Application.Services.Items;

namespace CatalogService.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IItemService, ItemService>();
            services.AddTransient<ICategoryService, CategoryService>();

            return services;
        }
    }
}
