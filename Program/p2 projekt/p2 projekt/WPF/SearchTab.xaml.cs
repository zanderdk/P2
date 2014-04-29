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
    public partial class SearchTab : UserControl
    {

        public SearchTab(Main ma)
        {
            InitializeComponent();

            SearchController.Main = ma;

            SearchController.ListToListBox += ListToListBox;

            Add_ControllerDelegates(name);
            Add_ControllerDelegates(birthday);
            Add_ControllerDelegates(phone);
            Add_ControllerDelegates(email);
            Add_ControllerDelegates(adresse);
            Add_ControllerDelegates(postal);
            Add_ControllerDelegates(country);
            Add_ControllerDelegates(memberID);
            Add_ControllerDelegates(memberSince);
            Add_ControllerDelegates(isActive);
            Add_ControllerDelegates(boatOwner);
            Add_ControllerDelegates(boatName);
            Add_ControllerDelegates(boatID);
            Add_ControllerDelegates(boatSpace);
            Add_ControllerDelegates(boatLength);
            Add_ControllerDelegates(boatWidth);
        }

        void addToDict(InfolineController c)
        {
            SearchController.Dict.Add(c.textbox, c);
        }

        void Add_ControllerDelegates(InfolineController c)
        {
            c.TextChanged +=  textbox_SearchChanged;
            c.GotFocus += TextBox_GotFocus;
            c.LostFocus += TextBox_LostFocus;
            addToDict(c);
        }

        void ListToListBox()
        {
            listResult.Items.Clear();
            foreach(var x in SearchController.List)
            {
                listResult.Items.Add(x);
            }
        }
        

        public void listResult_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListResultBoats.Items.Clear();
            User user = (User)(sender as ListBox).SelectedItem;
            if(user != null)
            {
                if(user is ISailor)
                {
                    foreach(Boat b in (user as ISailor).Boats)
                    {
                        ListResultBoats.Items.Add(b);
                    }
                }
            }
        }

        private void listResult_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            User user = (User)(sender as ListBox).SelectedItem;
            if(user != null)
            {
                SearchController.Main.selectUser(user);
            }
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            SearchController.TextBox_GotFocus(sender, e);
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e) //TODO fix internalRefresh
        {
            SearchController.TextBox_LostFocus(sender, e);
        }

        private void textbox_SearchChanged(object sender, TextChangedEventArgs e)
        {
            SearchController.textbox_SearchChanged(sender, e);
        }


     }
}
