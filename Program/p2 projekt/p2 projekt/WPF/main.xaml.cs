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
using System.Windows.Shapes;
using p2_projekt.models;


namespace p2_projekt.WPF
{
    /// <summary>
    /// Interaction logic for main.xaml
    /// </summary>
    public partial class main : Window
    {
        User loggedIn;
        public UserController controller;
        public main(User u)
        {
            InitializeComponent();

            this.Width = Properties.Settings.Default.appWidth;
            this.Height = Properties.Settings.Default.appLenght;
            

            loggedIn = u;

            controller = Utilities.lobopDB;

            AddToTabController(new WelcomeTab(u), "Forside");

            AddToTabController(new TabMap(), "Kort");
            
            if (Permission.CanRead(u.Permission.ChangePersonalInfo))
            {
                AddToTabController(new MemberInfo(u), "Profil");
            }

            if (Permission.CanRead(u.Permission.Search))
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

        public void selectUser(User u)
        {
            if(Permission.CanRead(loggedIn.Permission.MemberInfo))
            {
                tabController.SelectedItem = GetTabItemByName("Profil");
                MemberInfo mem = (MemberInfo)(tabController.SelectedItem as TabItem).Content;
                mem.InitUser(u);
            }
        }

        private void LogUdClick(object sender, RoutedEventArgs e)
        {
            ChipRequester ChipReq = new ChipRequester();
            ChipReq.Show();
            this.Close();
        }

        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Properties.Settings.Default.appWidth = this.Width;
            Properties.Settings.Default.appLenght = this.Height;
            Properties.Settings.Default.Save();
        }
    }
}
