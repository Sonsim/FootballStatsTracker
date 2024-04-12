using FootballStatsTrackerAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace FootballStatsTrackerAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<User> users { get; set; }
        public DbSet<Teams> teams { get; set; }
    }
}
