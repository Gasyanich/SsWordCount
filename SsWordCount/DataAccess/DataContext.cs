using Microsoft.EntityFrameworkCore;
using SsWordCount.DataAccess.Entities;

namespace SsWordCount.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<PageWordCount> WebPages { get; set; }
        public DbSet<WordCount> WordCounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=WordCount.db");
        }
    }
}