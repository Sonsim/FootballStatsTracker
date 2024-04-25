using FootballStatsTrackerClient.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;
using FootballStatsTrackerClient.Pages;

namespace FootballStatsTrackerClient.Viewmodel
{
    public class MainpageViewModel : INotifyPropertyChanged
    {
        private User _loggedIn;
        public User LoggedIn
        {
            get { return _loggedIn; }
            set
            {
                _loggedIn = value;
                OnPropertyChanged(nameof(LoggedIn));
            }
        }

        private Team _loggedTeam;
        public Team LoggedTeam
        {
            get { return _loggedTeam; }
            set
            {
                _loggedTeam = value;
                OnPropertyChanged(nameof(LoggedTeam));
            }
        }

        public MainpageViewModel()
        {
            GetTheme();
            
        }
        private void GetTheme()
        {
            LoggedIn = Globals.LoggedInUser;

            foreach (var team in Globals.teamsList)
            {
                if (team.teamname.ToLower() == LoggedIn.team.ToLower())
                {
                    LoggedTeam = team;
                }
            }
        }
        

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
