﻿using System;
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
using System.Windows.Shapes;
using p2_projekt.models;

namespace p2_projekt.WPF
{
    /// <summary>
    /// Interaction logic for TravelAddPopup.xaml
    /// </summary>
    public partial class TravelAddPopup : Window
    {
        User traveller;

        public TravelAddPopup(User u)
        {
            InitializeComponent();

            traveller = u;

        }

        private void AddChosenTravel(object sender, RoutedEventArgs e)
        {
            if (LeavingDate.SelectedDate.Value.Subtract(DateTime.Now).Days < 0)
            {
                MessageBox.Show("Vælg nyere Udrejse dato");
                return;
            }
            else if(ArrivalDate.SelectedDate.Value.Subtract(DateTime.Now).Days < 0)
            {
                MessageBox.Show("Vælg ny Hjemkost dato");
                return;
            }
            else
            {
                Travel TravelToBeAdded = new Travel() { Start = LeavingDate.SelectedDate.Value, End = ArrivalDate.SelectedDate.Value, User = traveller };
            }

            UserController uc = Utilities.lobopDB;
            uc.Update<User>(traveller);

            this.Close();
        }
    }
}
