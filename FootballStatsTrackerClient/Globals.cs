using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using FootballStatsTrackerClient.Model;

namespace FootballStatsTrackerClient
{
    public static class Globals
    {
        
        public static List<Team> teamsList = new List<Team>()
        {
            
        };

        public static User LoggedInUser { get; set; }

       
        public static async Task<object> FillList()
        {
            var list = new List<Team>();
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://localhost:7137/api/getTeams");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var items = JsonSerializer.Deserialize<List<Team>>(json);

                foreach (var team in items)
                {
                    list.Add(team);
                }

                teamsList = list;
                return list;
            }
            else
            {
                return null;
            }
        }
    }
}
