using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using FootballStatsTrackerClient.Model;
using FootballStatsTrackerClient;
using static System.Net.WebRequestMethods;


namespace FootballStatsTrackerClient.Pages
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Page
    {
        
        public Register()
        
        {
            InitializeComponent();
            List<Team> teams = Globals.teamsList;
            listBoxTeams.ItemsSource = teams;
        }

        private void BackToLoginBtn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Login());
        }

        
        private Team GetTeam()
        {
            var selectedListBoxItems = ((Team)listBoxTeams.SelectedItem).teamname;

            for (int i = 0; i < Globals.teamsList.Count; i++)
            {
                if (Globals.teamsList[i].teamname.ToLower().Contains(selectedListBoxItems.ToLower()))
                {
                    return Globals.teamsList[i];
                }
            }

            return null;
        }

        private async Task<bool> UsernameCheck(string username)
        {
            bool result;
            HttpClient client = new HttpClient();
            var url = "https://localhost:7137/api/User/checkusername?username=" + username;
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                result = JsonSerializer.Deserialize<bool>(content);

                return result;
            }
            else
            {
                result = false;
                return result;
            }
        }
        
         private async void RegisterBtn_Click(Object sender, RoutedEventArgs e)
         {
             var usernamecheck = await UsernameCheck(Register_Username.Text);

             if (usernamecheck)
             {
                 if (Register_Password.Password != Repeat_Password.Password || Register_Username.Text.Length == 0)
                 {
                     errorMessage.Text = "Sjekk brukernavn og passord";
                 }
                 else
                 {
                     string username = Register_Username.Text;
                     string teamname = ((Team)listBoxTeams.SelectedItem).teamname;
                     string passwordtext = Register_Password.Password;
                     string Salt;
                     string password;
                     Globals.GenerateSaltedhash(passwordtext, out password, out Salt);
                     Team club = GetTeam();
                     if (Register_Password.Password.Length == 0)
                     {
                         errorMessage.Text = "Skriv et passord";

                     }
                     else if (Register_Password.Password != Repeat_Password.Password)
                     {
                         errorMessage.Text = "Passordet matcher ikke";

                     }
                     else
                     {
                         await RegisterUserInDatabase(username, teamname, password, Salt);
                     }

                 }
             }
             else
             {
                 errorMessage.Text = "Brukernavn er opptatt";
             }
         }

         private async Task RegisterUserInDatabase(string username, string teamname, string password, string Salt)
         {
             User newuser = new User(username, teamname, password, Salt);


             string jsonUser = JsonSerializer.Serialize(newuser);

             HttpClient client = new HttpClient();
             HttpContent content = new StringContent(jsonUser, Encoding.UTF8, "application/json");
             HttpResponseMessage response =
                 await client.PostAsync("https://localhost:7137/create-user", content);

             if (response.IsSuccessStatusCode)
             {
                 Globals.LoggedInUser = newuser;
                 this.NavigationService.Navigate(new Mainpage());
             }
             else
             {
                 string messageBoxText = "Feil ved innlogging";
                 string caption = "Feil!";
                 MessageBoxButton button = MessageBoxButton.YesNoCancel;
                 MessageBoxImage icon = MessageBoxImage.Warning;
                 MessageBoxResult result;

                 result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
             }
         }
    }
}
