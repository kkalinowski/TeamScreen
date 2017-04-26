using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using TeamScreen.Data.Context;

namespace TeamScreen.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20170414193025_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
