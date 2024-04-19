using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Text.Json;
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
        public User LoggedIn { get; set; }
        public Team LoggedTeam { get; set; }
        private bool _home;
        private bool _away;

        public Mainpage()
        {
            GetTheme();
            InitializeComponent();
        }
        
        private  void GetTheme()
        {
            LoggedIn = Globals.LoggedInUser;

           foreach (var team in Globals.teamsList)
           {
               if (team.teamname.ToLower() == LoggedIn.team.ToLower())
               {
                   LoggedTeam = team;
                   DataContext = team;
               }
           }
        }

        public void AwayTheme_Click(object sender, RoutedEventArgs e)
        {
            var converter = new BrushConverter();
            
                this.Background = (Brush)converter.ConvertFromString(LoggedTeam.awaymaincolor);
                this.Foreground = (Brush)converter.ConvertFromString(LoggedTeam.awaysecondcolor);

                Button1.Background = (Brush)converter.ConvertFromString(LoggedTeam.awaysecondcolor);
                Button1.Foreground = (Brush)converter.ConvertFromString(LoggedTeam.awaymaincolor);

                Button2.Background = (Brush)converter.ConvertFromString(LoggedTeam.awaysecondcolor);
                Button2.Foreground = (Brush)converter.ConvertFromString(LoggedTeam.awaymaincolor);

                Button3.Background = (Brush)converter.ConvertFromString(LoggedTeam.awaysecondcolor);
                Button3.Foreground = (Brush)converter.ConvertFromString(LoggedTeam.awaymaincolor);
        }

        public void HomeTheme_Click(object sender, RoutedEventArgs e)
        {
            var converter = new BrushConverter();
            this.Background = (Brush)converter.ConvertFromString(LoggedTeam.homemaincolor);
            this.Foreground = (Brush)converter.ConvertFromString(LoggedTeam.homesecondcolor);

            Button1.Background = (Brush)converter.ConvertFromString(LoggedTeam.homesecondcolor);
            Button1.Foreground = (Brush)converter.ConvertFromString(LoggedTeam.homemaincolor);

            Button2.Background = (Brush)converter.ConvertFromString(LoggedTeam.homesecondcolor);
            Button2.Foreground = (Brush)converter.ConvertFromString(LoggedTeam.homemaincolor);

            Button3.Background = (Brush)converter.ConvertFromString(LoggedTeam.homesecondcolor);
            Button3.Foreground = (Brush)converter.ConvertFromString(LoggedTeam.homemaincolor);
        }

        public void LoggOffbtn_Click(object sender, RoutedEventArgs e)
        {
            Globals.LoggedInUser = null;
            NavigationService.Navigate(new Login());
        }


    }
}
