using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace FootballStatsTrackerAPI.Model
{
    public class User
    {
        [Required]
        [Key]
        public string username { get;  set; }
        
        public string team { get; set; }
        [Required]
        public string passwordhash { get;  set; }

    }
}
