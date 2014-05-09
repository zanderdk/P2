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
    public partial class Main : Window
    {
        public static User LoggedIn {get; private set; }
        public DALController Controller;

        public Main(User u)
        {
            InitializeComponent();

            Width = Properties.Settings.Default.appWidth;
            Height = Properties.Settings.Default.appLenght;

            MainController.Main = this;

            LoggedIn = u;

            AddToTabController(new WelcomeTab(u), "Forside");

            if(Permission.CanRead(Main.LoggedIn.Permission.Map))
                AddToTabController(new TabMap(), "Kort");
            
            if (Permission.CanRead(u.Permission.PersonalInfo))
            {
                AddToTabController(new MemberInfo(u), "Brugeradministration");
            }

            if (Permission.CanRead(u.Permission.OtherUsers))
            {
                AddToTabController(new SearchTab(this), "Søg");
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
                if (selected != null) selected.Content = new MemberInfo(u);
            }
        }

        private void LogUdClick(object sender, RoutedEventArgs e)
        {
            ChipRequester chipReq = new ChipRequester();
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
