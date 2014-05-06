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


        private void listBoats_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            Boat b = ((sender as ListBox).SelectedItem as Boat);

            viewModel.Boat = b;
        }

        private void listTravels_SelectionChanged(object sender, SelectionChangedEventArgs e)
         {
             Travel selectedItem = (sender as ListBox).SelectedItem as Travel;
             viewModel.Travel = selectedItem;
         }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Button_AddPerson(object sender, RoutedEventArgs e)
        {
            try
            {
                User u = parseParameters();
                Utilities.LobopDB.Add(u);
                MessageBox.Show("Bruger oprettet.");
                
            }catch (ArgumentException arg)
            {
                if (arg.Message == "ID")
                    MessageBox.Show("Id ikke gyldigt");

                if (arg.Message == "par")
                    MessageBox.Show("følgende felter skal udfyldes: \n Navn, Fødselsdag, tlf. nr., postnr., Adresse, Land, By");
                else
                {
                    MessageBox.Show(arg.Message);
                }
            }
        }

        private void Button_ChangeUser(object sender, RoutedEventArgs e)
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

        User parseParameters()
        {
            User user;

            if (name.Text == "" || birthday.Text == "" ||
                phone.Text == "" || adresse.Text == "" ||
                postal.Text == "" || country.Text == ""||
                city.Text == "" || memberSince.Text != "")
            {
                throw new ArgumentException("par");
            }


            if(memberRadio.IsChecked == true)
            {
                if(memberID.Text != "")
                {
                    int id;
                    if (!int.TryParse(memberID.Text, out id))
                        throw new ArgumentException("ID");

                    user = new Member(name.Text, new System.Device.Location.CivicAddress() { AddressLine1 = adresse.Text, City = city.Text, CountryRegion = country.Text, PostalCode=postal.Text}, id);
                }
                else
                {
                    user = new Member(name.Text, new System.Device.Location.CivicAddress() { AddressLine1 = adresse.Text, City = city.Text, CountryRegion = country.Text, PostalCode = postal.Text });
                }

                ((Member)user).Birthday = Convert.ToDateTime(birthday.Text);

                //if(registrationNumber.Text != "")
                //{
                //    ((Member)user).RegistrationDate = Convert.ToDateTime(registrationNumber.Text);
                //}

                if(email.Text != "")
                {
                    ((Member)user).Email = email.Text;
                }

                //if(travelList.Items.Count > 0)
                //{
                //    foreach(Travel t in travelList.Items){
                //        ((Member)user).Travels.Add(t);
                //    }
                //}

            }
            else if(adminRadio.IsChecked == true)
            {
                user = new HarbourMaster(name.Text) { Adress = new System.Device.Location.CivicAddress() { AddressLine1 = adresse.Text, City = city.Text, CountryRegion = country.Text, PostalCode = postal.Text } };

                ((HarbourMaster)user).Birthday = Convert.ToDateTime(birthday.Text);

                if (email.Text != "")
                {
                    ((HarbourMaster)user).Email = email.Text;
                }

            }
            else
            {
                throw new NotImplementedException("FATAL ERROR");
            }

            if(user is ISailor)
            {
                if(listBoats.Items.Count > 0)
                {
                    foreach(Boat b in listBoats.Items)
                    {
                        //(user as ISailor).Boats.Add(b);
                    }
                }
            }

            user.Phone = phone.Text;

            return user;
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
            new BoatPopup(viewModel.Boat, viewModel.User as ISailor).Show();
        }

        private void RemoveBoat(object sender, RoutedEventArgs e)
        {
            Boat boat = viewModel.Boat;
            ISailor sailor = viewModel.User as ISailor;
            new BoatController().Delete(boat, sailor);
        }
    }
}