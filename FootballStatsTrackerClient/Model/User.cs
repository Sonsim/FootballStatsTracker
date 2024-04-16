using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballStatsTrackerClient.Model
{
    public class User
    {
        public string username { get; set; }
        public string team { get; set; }
        public string passwordhash { get;  set; }

        public User(string Username, string password, string teamobject )
        {
            username = Username;
            team = teamobject;
            passwordhash = password;
        }

        
    }
}
