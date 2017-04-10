using Microsoft.EntityFrameworkCore;
using TeamScreen.Data.Entities;

namespace TeamScreen.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Setting> Settings { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Setting>().HasKey(x => x.Id);
            base.OnModelCreating(builder);
        }
    }
}
