using FootballStatsTrackerAPI.Data;
using FootballStatsTrackerAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace FootballStatsTrackerAPI.Services
{
    public class Userservice : IUserService
    {
        private readonly AppDbContext _dbContext;

        public Userservice(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<User> GetUsernameAndPasswordAsync(string username, string password)
        {
            return await _dbContext.users.FirstOrDefaultAsync(u =>
                u.username == username && u.passwordhash == password);
        }
    }
}
