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
using System.Windows.Navigation;
using System.Windows.Shapes;
using p2_projekt.models;

namespace p2_projekt.WPF
{
    /// <summary>
    /// Interaction logic for add.xaml
    /// </summary>
    public partial class add : UserControl
    {
        Person person;
        public add()
        {
            InitializeComponent();
        }

        public add(Person p) : this()
        {
            initPerson(p);
        }

        void initPerson(Person p)
        {
            fillPerson(p);
            if(p.boats != null)
            {
                foreach(Boat b in p.boats)
                {
                    listBoats.Items.Add(b);
                }
            }
        }

        public void fillBoat(Boat b)
        {
            txtBoatName.Text = b.Name;
            txtBoatOwner.Text = b.Owner.Name;
            txtBoatLenght.Text = b.Lenght.ToString();
            txtBoatWidth.Text = b.Width.ToString();
            if(b.Space != null)
            {   txtBoatSpaceId.Text = b.Space.Id.ToString();
                txtBoatSpaceString.Text = b.Space.info; 
            }
            txtBoatReg.Text = b.registrationNumber;
        }

        public void fillPerson(Person p)
        {
            //TODO label hvorvidt person er medlem eller gæst.
            //TODO tilføj/fjern båd skal ikke være mulig for alle.
            person = p;
            this.txtName.Text = p.Name;

            if (p.Birthday != null)
            {
                txtBirth.Text = p.Birthday.ToString();
            }
            
            if(p.Adress != null)
            {
                txtCity.Text = p.Adress.City;
                txtPostalCode.Text = p.Adress.PostalCode;
                txtAddress.Text = p.Adress.AddressLine1;
            }

            if(p is Member)
            {
                txtPhone.Text = ((Member)p).Phone.ToString();
                txtEmail.Text = ((Member)p).Email;
                txtMemberNr.Text = ((Member)p).MembershipNumber.ToString();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void listBoats_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fillBoat(e.AddedItems[0] as Boat);
        }
    }
}
