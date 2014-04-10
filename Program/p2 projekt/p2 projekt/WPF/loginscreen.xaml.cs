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
using System.Device.Location;

namespace p2_projekt.WPF
{
    /// <summary>
    /// Interaction logic for loginscreen.xaml
    /// </summary>
    public partial class loginscreen : Window
    {

        Member Andreas = new Member()
        {
            Name = "Andreas Hansen",
            UserId = 12653,
            Password = "1234bob",
            Permissions = new Permissions() 
            {
                member = true, 
                readOnlyMember = false
            },
            Adress = new CivicAddress()
            {
                AddressLine1 = "Bobstreet 5",
                PostalCode = "1337",
                CountryRegion = "Fyn"
            }          
        };     

        public loginscreen()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Andreas.Boats.Add(new Boat() { User = Andreas, Name = "testboat1", Width = 3, Lenght = 4, registrationNumber = "3424234" });
            Andreas.Boats.Add(new Boat() { User = Andreas, Name = "testboat2", Width = 3, Lenght = 4, registrationNumber = "3424435345234" });

            Andreas.Permissions = new Permissions() { member = true, readOnlyMember = true };


            if (Andreas.Password == password.Password)
            {
                main main = new main(Andreas);
                main.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Bad login");
            }
        }
    }
}

