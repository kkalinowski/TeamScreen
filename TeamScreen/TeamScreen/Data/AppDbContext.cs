using Microsoft.EntityFrameworkCore;
using TeamScreen.Data.Entities;

namespace TeamScreen.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<PluginSetting> Settings { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PluginSetting>().HasKey(x => x.Id);
            base.OnModelCreating(builder);
        }
    }
}
