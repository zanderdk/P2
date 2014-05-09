using System;
using System.Windows;
using System.Windows.Controls;
using p2_projekt.models;
using p2_projekt.controllers;


namespace p2_projekt.WPF
{
    /// <summary>
    /// Interaction logic for main.xaml
    /// </summary>
    public partial class FunctionContainer : Window
    {
        public static User LoggedIn {get; private set; }
        public DALController Controller;

        public FunctionContainer(User u)
        {
            InitializeComponent();

            Width = Properties.Settings.Default.appWidth;
            Height = Properties.Settings.Default.appLenght;

            FunctionController.Main = this;

            LoggedIn = u;

            AddToTabController(new Welcome(u), "Forside");

            if(Permission.CanRead(FunctionContainer.LoggedIn.Permission.Map))
                AddToTabController(new Map(), "Kort");
            
            if (Permission.CanRead(u.Permission.PersonalInfo))
            {
                AddToTabController(new UserInfo(u), "Brugeradministration");
            }

            if (Permission.CanRead(u.Permission.OtherUsers))
            {
                AddToTabController(new Search(this), "Søg");
            }
        }

        public void AddToTabController(UserControl us, string name)
        {
            TabItem tabItem = new TabItem() { Header = name, Content = us, Margin=new Thickness(0) };
            tabController.Items.Add(tabItem);
        }

        TabItem GetTabItemByName(string name)
        {
            foreach(TabItem tab in tabController.Items)
            {
                if(tab.Header == name)
                {
                    return tab;
                }
            }
            throw new InvalidOperationException();
        }

        public void SelectUser(User u)
        {
            if(Permission.CanRead(LoggedIn.Permission.PersonalInfo))
            {
                tabController.SelectedItem = GetTabItemByName("Brugeradministration");
                TabItem selected = tabController.SelectedItem as TabItem;
                if (selected != null) selected.Content = new UserInfo(u);
            }
        }

        private void LogUdClick(object sender, RoutedEventArgs e)
        {
            Standby chipReq = new Standby();
            chipReq.Show();
            Close();
        }

        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Properties.Settings.Default.appWidth = Width;
            Properties.Settings.Default.appLenght = Height;
            Properties.Settings.Default.Save();
        }
    }
}
