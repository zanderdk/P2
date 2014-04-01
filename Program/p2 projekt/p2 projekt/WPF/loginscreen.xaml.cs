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
    /// Interaction logic for loginscreen.xaml
    /// </summary>
    public partial class loginscreen : Window
    {

        public loginscreen()
        {
            InitializeComponent();
              
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            HarbourMaster harbourMaster = new HarbourMaster() { Name="Per" };
            //harbourMaster.Birthday = new DateTime(1967, 12, 24, 10, 0, 1, 12);
            //harbourMaster.Adress = new System.Device.Location.CivicAddress() { AddressLine1 = "Nørrebro 3", City = "Aalborg", PostalCode = "9700" };
            harbourMaster.Permissions = new Permissions() { member = true, readOnlyMember = true };
            WaterSpace space = new WaterSpace(0, 10, 10);
            harbourMaster.boats.Add(new Boat() { Name="test", Id=0, Owner=harbourMaster, Lenght=10, registrationNumber="F1dgdsfg", Width=10, Space=space });
            

            main main = new main(harbourMaster);// fix shit
            main.Show();
            this.Close();
        }
    }

}

