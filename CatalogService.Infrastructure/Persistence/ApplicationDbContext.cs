namespace CatalogService.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
        Database.Migrate();
    }

    //protected readonly IConfiguration Configuration;

    //public ApplicationDbContext(IConfiguration configuration)
    //{
    //    Configuration = configuration;
    //}

    //protected override void OnConfiguring(DbContextOptionsBuilder options)
    //{
    //    // connect to sqlite database
    //    options.UseSqlite(Configuration.GetConnectionString("WebApiDatabase"));
    //}
}
