﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using FootballStatsTrackerClient.Model;
using FootballStatsTrackerClient;


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
            DataContext = Globals.teamsList;
        }

        private void BackToLoginBtn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Login());
        }

        

        private string  GetTeamName()
        {
            string name = Club.Text;

            for (int i = 0; i < Globals.teamsList.Count; i++)
            {
                if (Globals.teamsList[i].teamname.ToLower().Contains(name.ToLower()))
                {
                    return Globals.teamsList[i].teamname;
                }
            }

            return String.Empty;
        }

        private Team GetTeam()
        {
            string name = Club.Text;

            for (int i = 0; i < Globals.teamsList.Count; i++)
            {
                if (Globals.teamsList[i].teamname.ToLower().Contains(name.ToLower()))
                {
                    return Globals.teamsList[i];
                }
            }

            return null;
        }
        private async void RegisterBtn_Click(Object sender, RoutedEventArgs e)
        {
            if (Register_Username.Text.Length == 0)
            {
                
                errorMessage.Text= "Vennligst skriv inn et brukernavn";
                
            }
            else
            {
                string username = Register_Username.Text;
                string teamname = GetTeamName();
                string password = Register_Password.Password;
                Team club = GetTeam();
                if (Register_Password.Password.Length == 0)
                {
                    errorMessage.Text = "Skriv et passord";
                    
                }
                else if(Register_Password.Password != Repeat_Password.Password)
                {
                    errorMessage.Text = "Passordet matcher ikke";
                    
                }
                else
                {
                     User newuser = new User(username,  password, club.teamname);
                     
                     
                     string jsonUser = JsonSerializer.Serialize(newuser);

                    HttpClient client = new HttpClient();
                    HttpContent content = new StringContent(jsonUser, Encoding.UTF8, "application/json");
                    HttpResponseMessage response =
                        await client.PostAsync("https://localhost:7137/create-user", content);

                    if (response.IsSuccessStatusCode)
                    {
                        Globals.LoggedInUser = username;
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
    }
}
