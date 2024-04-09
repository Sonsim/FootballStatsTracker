using System.ComponentModel.DataAnnotations;

namespace FootballStatsTrackerAPI.Model
{
    public class User
    {
        public string UserName { get; private set; }
        [Required]
        public string FavoriteTeam { get; set; }
        public int ID { get; private set; }
        public string _passwordHash { get; private set; }
    }
}
