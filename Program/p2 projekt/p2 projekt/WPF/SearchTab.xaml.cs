using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using p2_projekt.models;
using p2_projekt.controllers;

namespace p2_projekt.WPF
{
    public partial class SearchTab : UserControl
    {

        public SearchTab(Main ma)
        {
            InitializeComponent();

            SearchController.ListToListBox += ListToListBox;

            AddControllerDelegates(name);
            AddControllerDelegates(birthday);
            AddControllerDelegates(phone);
            AddControllerDelegates(email);
            AddControllerDelegates(adresse);
            AddControllerDelegates(postal);
            AddControllerDelegates(country);
            AddControllerDelegates(memberID);
            AddControllerDelegates(memberSince);
            AddControllerDelegates(isActive);
            AddControllerDelegates(boatOwner);
            AddControllerDelegates(boatName);
            AddControllerDelegates(boatID);
            AddControllerDelegates(boatSpace);
            AddControllerDelegates(boatLength);
            AddControllerDelegates(boatWidth);
        }

        void addToDict(InfolineControl c)
        {
            SearchController.Dict.Add(c.textbox, c);
        }

        void AddControllerDelegates(InfolineControl c)
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
                MainController.SelectUser(user);
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
