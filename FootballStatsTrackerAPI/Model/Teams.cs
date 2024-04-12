using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace FootballStatsTrackerAPI.Model
{
    public class Teams
    {
        [Key]
        public string teamname { get; set; }
        public string homemaincolor { get; set; }
        public string homesecondcolor { get; set; }
        public string awaymaincolor { get; set; }
        public string awaysecondcolor { get; set; }
    }
}
