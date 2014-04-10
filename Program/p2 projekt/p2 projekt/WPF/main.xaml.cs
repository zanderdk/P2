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


            WelcomeTab welcome = new WelcomeTab();
            TabItem welcomeTab = new TabItem() { Header = "Forside", Content = welcome };
            this.tabControler.Items.Add(welcomeTab);

            MemberInfo sailorInfo = new MemberInfo((ISailor)u);            
            TabItem sailorInfoTab = new TabItem() { Header = "Profil", Content = sailorInfo };
            this.tabControler.Items.Add(sailorInfoTab);
            
        }

       //TODO opret kun efter permissions

    }
}
