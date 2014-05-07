using System;
using System.Collections.Generic;
using System.Linq;
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
using p2_projekt.models;
using p2_projekt.controllers;

namespace p2_projekt.WPF
{
    //TODO Synlighed ved "aktiv" felt
    public partial class MemberInfo : UserControl
    {
        private MemberInfoController viewModel;

        public MemberInfo()
        {
            InitializeComponent();
            
        }

        public MemberInfo(User s)
            : this()
        {
            InitUser(s);
        }


        public void InitUser(User u)
        {
            viewModel = new MemberInfoController(u);
            if (u is ISailor)
            {
                InitSailor(u as ISailor);
            }

            DataContext = viewModel;
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
             viewModel.Travel = selectedItem;
         }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void AddNewTravel(object sender, RoutedEventArgs e)
        {
            TravelPopup AddingTravel = new TravelPopup(viewModel.User as ISailor);
            AddingTravel.Show();
        }

        private void Button_EditTravel(object sender, RoutedEventArgs e)
        {
            new TravelPopup(viewModel.Travel, viewModel.User as ISailor).Show();
        }

        private void Button_RemoveTravel(object sender, RoutedEventArgs e)
        {
            ISailor sailor = viewModel.User as ISailor;
            new TravelController().Delete(viewModel.Travel, sailor);
        }

        private void AddTravel_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            new TravelPopup(viewModel.User as ISailor).Show();
        }

        private void AddTravel_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = viewModel.User is ISailor;
        }

        private void ChangeBoat(object sender, RoutedEventArgs e)
        {
            new BoatPopup(viewModel.Boat).Show();
        }

        private void Button_RemoveUser(object sender, RoutedEventArgs e)
        {
            DALController us = Utilities.LobopDB;
            us.Remove(viewModel.User);
            DataContext = null;
            viewModel.User = null;
        }

        private void add_canExecute(object sender, CanExecuteRoutedEventArgs e)
        {

        }

        private void add_executed(object sender, ExecutedRoutedEventArgs e)
        {

        }
    }
}