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
        private User Current;
        public Boat SelectedBoat { get; set; }
        public Travel SelectedTravel { get; set; }

        public MemberInfo()
        {
            InitializeComponent();
            
        }

        public MemberInfo(User s)
            : this()
        {
            InitUser(s);
            
            
            //new NewBoatPopup((Current as ISailor).Boats[0]).Show();
        }


        public void InitUser(User u)
        {
            Current = u;
            
            if (u is ISailor)
            {
                InitSailor(u as ISailor);
            }
            DataContext = new
            {
                User = Current,
                Boat = SelectedBoat,
                Travel = SelectedTravel
            };
        }

        void InitSailor(ISailor s)
        {
            FillSailor(s);
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

            if (s is Member) { NewTravelButton.IsEnabled = true; }
            }

        private void SetDefaultSelectedItem(ISailor s, ListBox list)
        {
            if (s.Boats.Count() > 0)
            {
                list.SelectedIndex = 0;
        }
        }

        public void FillBoat(Boat b)
        {
            //boatName.Text = b.Name;
            ////boatOwner.Text = b.User.Name;
            //boatLength.Text = b.Length.ToString();
            //boatWidth.Text = b.Width.ToString();
            //if (b.BoatSpace != null)
            //{
            //    boatSpace.Text = b.BoatSpace.ToString();
            //}
            //boatID.Text = b.RegistrationNumber;
        }

        private void FillTravel(Travel t)
        {
            //travelStart.Text = t.Start.ToShortDateString();
            //travelEnd.Text = t.End.ToShortDateString();
        }

        public void FillSailor(ISailor s)
        {
            //TODO label hvorvidt Sailor er medlem eller gæst.
            //TODO tilføj/fjern båd skal ikke være mulig for alle.

            User u = (User)s;
            //name.Text = u.Name;
            //phone.Text = u.Phone;
            //adresse.Text = u.Adress.AddressLine1;
            //postal.Text = u.Adress.PostalCode;
            //country.Text = u.Adress.CountryRegion;
            //city.Text = u.Adress.City;
            IFullPersonalInfo fullPersonalInfo = u as IFullPersonalInfo;
            if (fullPersonalInfo != null)
            {
                //birthday.Text = fullPersonalInfo.Birthday.ToString();

                
                //email.Text = fullPersonalInfo.Email.ToString();

            }
            //Member Member = u as Member;
            //if (Member != null)
            //{
               
            //}

        }

        private void listBoats_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            Boat b = ((sender as ListBox).SelectedItem as Boat);
            SelectedBoat = b;
            if((sender as ListBox).SelectedItem != null)
            {
                //FillBoat(b); 
            }
        }

        private void listTravels_SelectionChanged(object sender, SelectionChangedEventArgs e)
         {
             Travel selectedItem = (sender as ListBox).SelectedItem as Travel;
             SelectedTravel = selectedItem;
             if (selectedItem != null)
             {
                 //FillTravel(selectedItem);
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

        public void ClearBoatInfo()
        {
            //boatName.Text = "";
            //boatOwner.Text = "";
            //boatLength.Text = "";
            //boatWidth.Text = "";
            //boatSpace.Text = "";
            //boatID.Text = "";
        }

        private void Button_ChangeUser(object sender, RoutedEventArgs e)
        {

        }

        private void AddNewTravel(object sender, RoutedEventArgs e)
        {
            TravelAddPopup AddingTravel = new TravelAddPopup(Current as ISailor);
            AddingTravel.Show();
        }


        private void Button_EditTravel(object sender, RoutedEventArgs e)
        {
            //Travel selectedItem = listTravels.SelectedItem as Travel;

            new TravelAddPopup(SelectedTravel, Current as ISailor).Show();

            //// We know it is a sailor, because otherwise he wouldn't be able to remove travel, so no need to null check
            //ISailor sailor = Current as ISailor;
            //if (selectedItem != null)
            //{
            //    Travel newTravel = new Travel(newStart, newEnd);
            //    int indexToReplace = sailor.Travels.IndexOf(selectedItem);
            //    sailor.Travels.Remove(selectedItem);
            //    sailor.Travels.Insert(indexToReplace, newTravel);
            //    UserController uc = Utilities.lobopDB;
            //    uc.Update<User>(sailor as User);
            //}

        }

        private void Button_RemoveTravel(object sender, RoutedEventArgs e)
        {
            Travel selectedItem = SelectedTravel;

            // We know it is a sailor, because otherwise he wouldn't be able to remove travel, so no need to null check
            ISailor sailor = Current as ISailor;


            if (selectedItem != null)
            {
                sailor.Travels.Remove(selectedItem);
                UserController uc = Utilities.lobopDB;
                uc.Update<User>(sailor as User);
                SelectedTravel = null;
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

        private void AddNewBoat(object sender, RoutedEventArgs e)
        {

        }

    }
}
