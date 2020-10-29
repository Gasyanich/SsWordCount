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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=WordCount.db");
        }

        public DbSet<PageWordCount> WebPages { get; set; }
        public DbSet<WordCount> WordCounts { get; set; }
    }
}