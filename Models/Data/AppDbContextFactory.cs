using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using JournalApp.Data;

namespace JournalApp.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlite("Data Source=journal.db");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
