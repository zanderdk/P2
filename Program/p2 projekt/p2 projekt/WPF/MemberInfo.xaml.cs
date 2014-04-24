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

            if (s is Member) { NewTravelButton.IsEnabled = true; }
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

            IFullPersonalInfo fullPersonalInfo = u as IFullPersonalInfo;
            if (fullPersonalInfo != null)
            {
                birthday.Text = fullPersonalInfo.Birthday.ToString();
            }
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
            
        }

        public void ClearBoatInfo()
        {
            boatName.Text = "";
            boatOwner.Text = "";
            boatLength.Text = "";
            boatWidth.Text = "";
            boatSpace.Text = "";
            boatID.Text = "";
        }

        private void AddNewTravel(object sender, RoutedEventArgs e)
        {
            TravelAddPopup AddingTravel = new TravelAddPopup(current);
            AddingTravel.Show();
        }
    }
}
