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
using System.Windows.Shapes;
using p2_projekt;
using p2_projekt.models;
using System.Device.Location;

namespace p2_projekt.WPF
{
    public partial class GuestCreator : Window
    {
        public GuestCreator()
        {
            InitializeComponent();
        }

        private void Save_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            //TODO Overvej felter: hvilken plads ligger gæsten på. Betaling

            Guest newGuest = new Guest()
            {
                Name = name.Text,
                Phone = phone.Text,
                Adress = new CivicAddress() { AddressLine1 = streetName.Text, PostalCode = postalCode.Text, CountryRegion = country.Text }
            };
            
            

            //TODO boat og travel skal også tilføjes

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
    }
}