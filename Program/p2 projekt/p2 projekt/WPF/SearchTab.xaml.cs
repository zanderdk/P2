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
    public partial class SearchTab : UserControl
    {
        public SearchTab()
        {
            InitializeComponent();

            Add_ControllerDelegates(name);
            Add_ControllerDelegates(birthday);
            Add_ControllerDelegates(phone);
            Add_ControllerDelegates(email);
            Add_ControllerDelegates(adresse);
            Add_ControllerDelegates(postal);
            Add_ControllerDelegates(country);
            Add_ControllerDelegates(memberID);
            Add_ControllerDelegates(memberSince);
            Add_ControllerDelegates(memberTimeTotal);
            Add_ControllerDelegates(isActive);
            Add_ControllerDelegates(boatOwner);
            Add_ControllerDelegates(boatName);
            Add_ControllerDelegates(boatID);
            Add_ControllerDelegates(boatSpace);
            Add_ControllerDelegates(boatLength);
            Add_ControllerDelegates(boatWidth);            
        }

        void Add_ControllerDelegates(InfolineController c)
        {
            c.TextChanged += delegate { textbox_SearchChanged(); };
        }

        void textbox_SearchChanged()
        {

        }

        void infobox(User u)
        {
            //TODO fill bonus info
        }

        public void listResult_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            infobox(e.AddedItems[0] as User);
        }

        private void listResult_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("magic!");
        }
    }
}
