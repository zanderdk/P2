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
        public main(User u)
        {
            InitializeComponent();

            AddToTabController(new TabMap(), "Kort");

            AddToTabController(new WelcomeTab(), "Forside");

           
           if(Permission.CanRead(u.Permission.ChangePersonalInfo))
           {
               AddToTabController(new MemberInfo(u), "Profil");
           }

            if(Permission.CanRead(u.Permission.search))
            {
                AddToTabController(new SearchTab(), "Søg");
            }
        }

            public void AddToTabController(UserControl us, string name)
            {
                TabItem tabItem = new TabItem() { Header = name, Content = us, Margin=new Thickness(0) };
                tabController.Items.Add(tabItem);
            }
            
        }
}
