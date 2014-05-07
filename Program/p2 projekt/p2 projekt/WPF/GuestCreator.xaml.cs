using System;
using System.Windows;
using System.Windows.Input;
using p2_projekt.models;
using System.Device.Location;
using p2_projekt.Enums;

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
                Adress = new CivicAddress() { 
                    AddressLine1 = streetName.Text, 
                    PostalCode = postalCode.Text,
                    CountryRegion = country.Text 
                },
                Permission = new Permission(){
                    PersonalInfo = PermissionLevel.Read,
                    OtherUsers = PermissionLevel.None
                }
            };

            double bLength = 0;
            double bWidth = 0;

            if(!double.TryParse(boatLength.Text, out bLength) || !double.TryParse(boatWidth.Text, out bWidth)){
                MessageBox.Show("Boat length or width not in valid format");
                return;
            }
            TimeSpan timespan = LeavingDate.SelectedDate.Value.Subtract(DateTime.Now);

            if (timespan.Days < 0)
            {
                MessageBox.Show("Leaving date must be in the future");
                return;
            }

            Boat boat = new Boat(boatName.Text, bLength, bWidth);
            newGuest.Boats.Add(boat);

            Travel t = new Travel(DateTime.Now, LeavingDate.SelectedDate.Value);
            newGuest.Travels.Add(t);
            

            try
            {
                DALController userController = Utilities.LobopDB;
                userController.Add(newGuest);
                ChipRequester ChipLogin = new ChipRequester(); //TODO overvej om den kan logge ind med det samme?
                ChipLogin.Show();
                this.Close();
            }

            catch (InvalidOperationException ex) //TODO User add exception
            {
                System.Windows.MessageBox.Show(ex.Message);
                this.Close();
            }


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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ChipRequester ChipLogin = new ChipRequester();
            ChipLogin.Show();
            this.Close();
        }
    }
}