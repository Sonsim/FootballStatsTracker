using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FootballStatsTrackerClient.Model
{
    public class User
    {
        public string username { get; set; }
        public string team { get; set; }
        public string passwordhash { get;  set; }
        public string salt { get; set; }

        public User(string Username, string password, string teamobject )
        {
            username = Username;
            team = teamobject;
            passwordhash = password;
        }
        [JsonConstructor]
        public User(string userName, string Team, string Passwordhash, string Salt)
        {
            username = userName;
            team = Team;
            passwordhash = Passwordhash;
            salt = Salt;
        }
    }
}
