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
            optionsBuilder.UseSqlite($"Data Source = {dbPath}")
                .LogTo(Console.WriteLine,Microsoft.Extensions.Logging.LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>().HasData(
                new Team
                {
                    TeamId = 1,
                    Name = "Tivoli Gardens FC",
                    CreatedDate = DateTime.Now,
                },
                new Team
                {
                    TeamId = 2,
                    Name = "Waterhouse FC",
                    CreatedDate = DateTime.Now,
                },
                new Team
                {
                    TeamId = 3,
                    Name = "Humble Lions FC",
                    CreatedDate = DateTime.Now,
                }
                ); 
        }
    }

}
