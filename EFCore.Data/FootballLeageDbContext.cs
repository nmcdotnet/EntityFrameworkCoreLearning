using EFCore.Domain;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Data
{
    public class FootballLeageDbContext : DbContext
    {
        string dbPath;
        public FootballLeageDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            dbPath = Path.Combine(path, "FootballLeage_EfCore.db"); 
        }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Coach> Coachs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source = {dbPath}"); 
        }

    }

}
