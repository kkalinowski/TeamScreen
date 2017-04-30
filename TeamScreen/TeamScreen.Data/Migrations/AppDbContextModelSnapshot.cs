using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using TeamScreen.Data.Context;

namespace TeamScreen.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1");

            modelBuilder.Entity("TeamScreen.Data.Entities.PluginSetting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Plugin");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.ToTable("PluginSettings");
                });
        }
    }
}
