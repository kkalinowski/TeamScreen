using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace TeamScreen.Data.Context
{
    //use only for Migration creation - http://benjii.me/2016/05/dotnet-ef-migrations-for-asp-net-core/
    //also that's why System.Collections.Immutable and System.Diagnostics.DiagnosticSource are referenced
    public class TemporaryDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext Create()
        {
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseSqlite("Data Source=TeamScreen.sqlite");
            return new AppDbContext(builder.Options);
        }

        public AppDbContext Create(DbContextFactoryOptions options)
        {
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseSqlite("Data Source=TeamScreen.sqlite");
            return new AppDbContext(builder.Options);
        }

        public AppDbContext CreateDbContext(string[] args)
        {
            throw new System.NotImplementedException();
        }
    }
}
