using CatalogService.Application.Common;
using CatalogService.Domain.Common;
using CatalogService.Infrastructure.Persistence;

namespace CatalogService.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext<BaseEntity>>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                        builder => builder.MigrationsAssembly(typeof(ApplicationDbContext<BaseEntity>).Assembly.FullName)));


            services.AddScoped<IApplicationDbContext<BaseEntity>>(provider => provider.GetRequiredService<ApplicationDbContext<BaseEntity>>());

            return services;
        }
    }
}
