using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FootballStatsTrackerClient.Model;

namespace FootballStatsTrackerClient.Pages
{
    /// <summary>
    /// Interaction logic for Mainpage.xaml
    /// </summary>
    public partial class Mainpage : Page
    {
        public Mainpage()
        {
            //GetTheme();
            InitializeComponent();
        }
        
        private async void GetTheme()
        {
           var user = await GetUser();

           
        }

        private static async Task<HttpContent> GetUser()
        {
            HttpClient client = new HttpClient();
            string url = "https://localhost:7137/api/User/" + Globals.LoggedInUser;

            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                return response.Content;
            }

            return null;
        }
    }
}
