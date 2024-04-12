using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballStatsTrackerClient.Model
{
    public class Team
    {
        public string teamname { get; set; }
        public string homemaincolor { get; set; }
        public string homesecondcolor { get; set; }
        public string awaymaincolor { get; set; }
        public string awaysecondcolor { get; set; }

        public Team(string teamname, string homemaincolor, string homesecondcolor, string awaymaincolor, string awaysecondcolor)
        {
            this.teamname = teamname;
            this.homemaincolor = homemaincolor;
            this.homesecondcolor = homesecondcolor;
            this.awaymaincolor = awaymaincolor;
            this.awaysecondcolor = awaysecondcolor;
        }
    }
}
