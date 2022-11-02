using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using net_advanced_course.DAL.Entities;
using net_advanced_course.DAL.Settings;

namespace net_advanced_course.DAL
{
    public class SqlDbContext : DbContext
    {
        private readonly SqlDbSettings _sqlDbSetting;

        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }

        public SqlDbContext(IOptions<SqlDbSettings> sqlDbSettingOptions)
        {
            _sqlDbSetting = sqlDbSettingOptions.Value;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(_sqlDbSetting.ConnectionString);
        }
    }
}
