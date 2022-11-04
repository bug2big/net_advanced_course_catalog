using CatalogService.Application.Common.Interfaces;
using CatalogService.Infrastructure.Persistence;

namespace CatalogService.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        
        services.AddScoped(typeof(IDbContextProvider<>), typeof(DbContextProvider<>));
        return services;
    }
}
