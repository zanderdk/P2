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
            HarbourMaster har = new HarbourMaster() { Name="per" };
            har.Birthday = new DateTime(1967, 12, 24, 10, 0, 1, 12);
            har.Adress = new System.Device.Location.CivicAddress() { AddressLine1 = "nørebro 3", City = "Aalborg", PostalCode = "9700" };
            har.Permissions = new Permissions() { member = true, readOnlyMember = false };
            WaterSpace space = new WaterSpace(0, 10, 10);
            har.boats.Add(new Boat() { Name="test", Id=0, Owner=har, Lenght=10, registrationNumber="fdgdsfg", Width=10, Space=space });
            

            main main = new main(har);// fix shit
            main.Show();
            this.Close();
        }
    }

}
