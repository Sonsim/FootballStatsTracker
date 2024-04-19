using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
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
using static System.Net.WebRequestMethods;

namespace FootballStatsTrackerClient.Pages
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }

        private void ToRegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Register());
        }

        public static bool VerifyPassword(string enteredPassword, string storedHash, string storedSalt)
        {
            var saltBytes = Convert.FromBase64String(storedSalt);
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(enteredPassword, saltBytes, 10000);
            return Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256)) == storedHash;
        }


        public async void LoginBtn_OnClick(object sender, RoutedEventArgs e)
        {
            string username = usernameInput.Text;
            string passwordinput = passwordInput.Password;
            var url = "https://localhost:7137/api/User/" + username;

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var responsebody = await response.Content.ReadAsStringAsync();
                var user = JsonSerializer.Deserialize<User>(responsebody);
                bool isPasswordMatched = VerifyPassword(passwordinput, user.passwordhash, user.salt);

                if (isPasswordMatched)
                {
                    Globals.LoggedInUser = user;
                    NavigationService.Navigate(new Mainpage());
                }
                else
                {
                    string messageBoxText = "Brukernavn eller passord er feil";
                    string caption = "Feil!";
                    MessageBoxButton button = MessageBoxButton.YesNoCancel;
                    MessageBoxImage icon = MessageBoxImage.Warning;
                    MessageBoxResult result;

                    result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
                }
            }
            

        }
    }
}
