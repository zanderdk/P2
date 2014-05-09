using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using p2_projekt.models;
using p2_projekt.controllers;

namespace p2_projekt.WPF
{
    //TODO Synlighed ved "aktiv" felt
    public partial class UserInfo : UserControl
    {
        private UserInfoController _controller;

        public UserInfo()
        {
            InitializeComponent();
            
        }

        public UserInfo(User s)
            : this()
        {
            InitUser(s);
        }


        public void InitUser(User u)
        {
            _controller = new UserInfoController(u);
            if (u is ISailor)
            {
                InitSailor(u as ISailor);
            }


            DataContext = _controller;
        }

        void InitSailor(ISailor s)
        {
            if (s.Boats != null)
            {
                listBoats.ItemsSource = s.Boats;
                SetDefaultSelectedItem(s, listBoats);
            }

            if (s.Travels != null)
                {
                listTravels.ItemsSource = s.Travels;
                SetDefaultSelectedItem(s, listTravels);
                }
            }

        private void SetDefaultSelectedItem(ISailor s, ListBox list)
        {
            if (list.Items.Count > 0)
            {
                list.SelectedIndex = 0;
            }
        }

        private void listTravels_SelectionChanged(object sender, SelectionChangedEventArgs e)
         {
             Travel selectedItem = (sender as ListBox).SelectedItem as Travel;
             _controller.Travel = selectedItem;
         }

        private void AddNewTravel(object sender, RoutedEventArgs e)
        {
            TravelPopup addingTravel = new TravelPopup(_controller.User as ISailor);
            addingTravel.Show();
        }

        private void Button_EditTravel(object sender, RoutedEventArgs e)
        {
            new TravelPopup(_controller.Travel, _controller.User as ISailor).Show();
        }

        private void Button_RemoveTravel(object sender, RoutedEventArgs e)
        {
            ISailor sailor = _controller.User as ISailor;
            new TravelController().Delete(_controller.Travel, sailor);
        }

        private void AddTravel_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            new TravelPopup(_controller.User as ISailor).Show();
        }

        private void AddTravel_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _controller.User is ISailor;
        }

        private void BoatSelected(object sender, RoutedEventArgs e)
        {
            
        }

        private void listBoats_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _controller.changeBoatCommand.RaiseCanExecuteChanged();
        }
    }
}
