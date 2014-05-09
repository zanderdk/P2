using System;
using System.Device.Location;
using System.Windows;
using System.Windows.Input;
using p2_projekt.controllers;
using p2_projekt.models;

namespace p2_projekt.WPF
{
    public partial class GuestCreator : Window
    {
        private GuestController controller;
        public GuestCreator()
        {
            InitializeComponent();
            Guest g = new Guest();
            g.Adress = new CivicAddress();
            controller = new GuestController(g);
            DataContext = g;
        }

        private void Save_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            //TODO Overvej felter: hvilken plads ligger gæsten på. Betaling
            double bLength;
            double bWidth;

            if (!double.TryParse(boatLength.Text, out bLength) || !double.TryParse(boatWidth.Text, out bWidth))
            {
                MessageBox.Show("Boat length or width not in valid format");
                return;
            }
            TimeSpan timespan = LeavingDate.SelectedDate.Value.Subtract(DateTime.Now);
            if (timespan.Days < 0)
            {
                MessageBox.Show("Leaving date must be in the future");
                return;
            }

            Boat b = new Boat(boatName.Text, bLength, bWidth);
            Travel t = new Travel(DateTime.Now, LeavingDate.SelectedDate.Value);
            if (controller.Save(b, t))
            {
                Standby chipLogin = new Standby(); //TODO overvej om den kan logge ind med det samme?
                chipLogin.Show();
                Close();
            }
            else
            {
                MessageBox.Show("fejl");
            }
        }

        private void Save_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = !(string.IsNullOrEmpty(name.Text))
                && !(string.IsNullOrEmpty(phone.Text))
                && !(string.IsNullOrEmpty(streetName.Text))
                && !(string.IsNullOrEmpty(postalCode.Text))
                && !(string.IsNullOrEmpty(country.Text))
                && !(string.IsNullOrEmpty(boatName.Text))
                && !(string.IsNullOrEmpty(boatLength.Text))
                && !(string.IsNullOrEmpty(boatWidth.Text))
                && !(string.IsNullOrEmpty(LeavingDate.ToString()));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Standby ChipLogin = new Standby();
            ChipLogin.Show();
            Close();
        }
    }
}