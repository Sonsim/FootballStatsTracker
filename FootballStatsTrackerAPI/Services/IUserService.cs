using FootballStatsTrackerAPI.Model;

namespace FootballStatsTrackerAPI.Services
{
    public interface IUserService
    {
        Task<User> GetUsernameAndPasswordAsync (string username, string password);
        Task<IQueryable<User>> GetUsernameAsync(string username);
    }
}
