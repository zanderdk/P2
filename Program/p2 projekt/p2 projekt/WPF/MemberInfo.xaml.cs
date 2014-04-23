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
        User current;

        public MemberInfo()
        {
            InitializeComponent();
        }

        public MemberInfo(User s)
            : this()
        {
            initUser(s);
        }


        public void initUser(User u)
        {
            current = u;
            if (u is ISailor)
            {
                initSailor(u as ISailor);
            }
        }

        void initSailor(ISailor s)
        {
            listBoats.Items.Clear();
            fillSailor(s);
            if (s.Boats != null)
            {
                foreach (Boat b in s.Boats)
                {
                    listBoats.Items.Add(b);
                }
            }
        }

        public void fillBoat(Boat b)
        {
            boatName.Text = b.Name;
            boatOwner.Text = b.User.Name;
            boatLength.Text = b.Length.ToString();
            boatWidth.Text = b.Width.ToString();
            if (b.BoatSpace != null)
            {
                boatSpace.Text = b.BoatSpace.ToString(); //TODO mere info om bådplads
            }
            boatID.Text = b.RegistrationNumber;
        }

        public void fillSailor(ISailor s)
        {
            //TODO label hvorvidt Sailor er medlem eller gæst.
            //TODO tilføj/fjern båd skal ikke være mulig for alle.

            User u = (User)s;
            name.Text = u.Name;
            phone.Text = u.Phone;
            adresse.Text = u.Adress.AddressLine1;
            postal.Text = u.Adress.PostalCode;
            country.Text = u.Adress.CountryRegion;
        }

        private void listBoats_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if((sender as ListBox).SelectedItem != null)
            {
                fillBoat(((sender as ListBox).SelectedItem as Boat)); 
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Button_AddPerson(object sender, RoutedEventArgs e)
        {
            try
            {
                User u = parseParameters();
                memberInfoController.validateUser(u);
                Utilities.lobopDB.Add(u);
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

                if(registrationNumber.Text != "")
                {
                    ((Member)user).RegistrationDate = Convert.ToDateTime(registrationNumber.Text);
                }

                if(email.Text != "")
                {
                    ((Member)user).Email = email.Text;
                }

                if(travelList.Items.Count > 0)
                {
                    foreach(Travel t in travelList.Items){
                        ((Member)user).Travels.Add(t);
                    }
                }

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

    }
}
