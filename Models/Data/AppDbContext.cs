using Microsoft.EntityFrameworkCore;
using Archiva.Models;

namespace Archiva.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<JournalEntry> JournalEntries { get; set; }
    }
}