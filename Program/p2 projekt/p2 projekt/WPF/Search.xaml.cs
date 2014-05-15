using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using p2_projekt.models;
using p2_projekt.controllers;
using System.Linq;
using System.Collections.Generic;

namespace p2_projekt.WPF
{
    public partial class Search : UserControl
    {
        private SearchController _controller;

        public Search(FunctionContainer ma)
        {
            InitializeComponent();

            _controller = new SearchController();

            
            _controller.ListUpdated += ListToListBox;


            var searchFieldsUser = searchfieldsContainerUser.Children.OfType<InfolineControl>().ToList();
            var searchFieldsBoat = searchfieldsContainerBoat.Children.OfType<InfolineControl>().ToList();

            foreach (var infolineControl in searchFieldsUser.Union(searchFieldsBoat))
            {
                infolineControl.TextChanged += textbox_SearchChanged;
                infolineControl.GotFocus += TextBox_GotFocus;
                infolineControl.LostFocus += TextBox_LostFocus;
                infolineControl.textbox.Tag = infolineControl.Tag;
            }

        }


        void ListToListBox(IEnumerable<User> list)
        {
            listResult.Items.Clear();
            foreach(var x in list)
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
                FunctionController.SelectUser(user);
            }
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            _controller.TextBox_GotFocus(textBox.Tag as string, textBox.Text);
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            _controller.TextBox_LostFocus(textBox.Tag as string, textBox.Text);
        }

        private void textbox_SearchChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            _controller.textbox_SearchChanged(textBox.Tag as string, textBox.Text);
        }
     }
}
