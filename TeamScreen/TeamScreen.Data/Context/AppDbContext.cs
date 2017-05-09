using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TeamScreen.Data.Entities;
using TeamScreen.Models;

namespace TeamScreen.Data.Context
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<PluginSetting> PluginSettings { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PluginSetting>().HasKey(x => x.Id);
            base.OnModelCreating(builder);
        }
    }
}
