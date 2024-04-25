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
using FootballStatsTrackerClient.Viewmodel;


namespace FootballStatsTrackerClient.Pages
{
    /// <summary>
    /// Interaction logic for Mainpage.xaml
    /// </summary>
    public partial class Mainpage : Page
    {
        private MainpageViewModel viewModel;

        public Mainpage()
        {
            InitializeComponent();
            viewModel = new MainpageViewModel();
            DataContext = viewModel;
        }

        private void AwayTheme_Click(object sender, RoutedEventArgs e)
        {
            var converter = new BrushConverter();
            Background = (Brush)converter.ConvertFromString(viewModel.LoggedTeam.awaymaincolor);
            Foreground = (Brush)converter.ConvertFromString(viewModel.LoggedTeam.awaysecondcolor);

            Home_Btn.Background = (Brush)converter.ConvertFromString(viewModel.LoggedTeam.awaysecondcolor);
            Home_Btn.Foreground = (Brush)converter.ConvertFromString(viewModel.LoggedTeam.awaymaincolor);
            Away_Btn.Foreground = (Brush)converter.ConvertFromString(viewModel.LoggedTeam.awaymaincolor);
            Away_Btn.Background = (Brush)converter.ConvertFromString(viewModel.LoggedTeam.awaysecondcolor);

            LoggOff_Btn.Background = (Brush)converter.ConvertFromString(viewModel.LoggedTeam.awaysecondcolor);
            LoggOff_Btn.Foreground = (Brush)converter.ConvertFromString(viewModel.LoggedTeam.awaymaincolor);

        }

        private void HomeTheme_Click(object sender, RoutedEventArgs e)
        {
            var converter = new BrushConverter();
            Background = (Brush)converter.ConvertFromString(viewModel.LoggedTeam.homemaincolor);
            Foreground = (Brush)converter.ConvertFromString(viewModel.LoggedTeam.homesecondcolor);

            Home_Btn.Background = (Brush)converter.ConvertFromString(viewModel.LoggedTeam.homesecondcolor);
            Home_Btn.Foreground = (Brush)converter.ConvertFromString(viewModel.LoggedTeam.homemaincolor);
            Away_Btn.Background = (Brush)converter.ConvertFromString(viewModel.LoggedTeam.homesecondcolor);
            Away_Btn.Foreground = (Brush)converter.ConvertFromString(viewModel.LoggedTeam.homemaincolor);

            LoggOff_Btn.Background = (Brush)converter.ConvertFromString(viewModel.LoggedTeam.homesecondcolor);
            LoggOff_Btn.Foreground = (Brush)converter.ConvertFromString(viewModel.LoggedTeam.homemaincolor);
        }

        private void LogOffbtn_Click(object sender, RoutedEventArgs e)
        {
            Globals.LoggedInUser = null;
            NavigationService.Navigate(new Login());
        }
    }


}
