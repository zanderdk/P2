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
using System.Windows.Navigation;
using System.Windows.Shapes;
using p2_projekt.models;

namespace p2_projekt.WPF
{
    //TODO Synlighed ved "aktiv" felt
    public partial class MemberInfo : UserControl
    {
        public MemberInfo()
        {
            InitializeComponent();
        }

        public MemberInfo(User s)
            : this()
        {
            if (s is ISailor)
            {
                initSailor(s as ISailor);
            }
        }

        void initSailor(ISailor s)
        {
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
            fillBoat(e.AddedItems[0] as Boat);
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

       
    }
}
