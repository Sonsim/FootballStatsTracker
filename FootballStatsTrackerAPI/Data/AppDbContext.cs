﻿using FootballStatsTrackerAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace FootballStatsTrackerAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
    }
}
