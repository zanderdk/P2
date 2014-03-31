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

        public void fillPerson(Person p)
        {
            //TODO label hvorvidt person er medlem eller gæst.
            //TODO tilføj/fjern båd skal ikke være mulig for alle.
            txtName.Content = p.Name;
            person = p;

            if (p.Birthday != null)
            {
                txtBirth.Content = p.Birthday;
            }
            
            if(p.Adress != null)
            {
                txtCity.Content = p.Adress.City;
                txtPostalCode.Content = p.Adress.PostalCode;
                txtAddress.Content = p.Adress.AddressLine1;
            }

            if(p is Member)
            {
                txtPhone.Content = ((Member)p).Phone;
                txtEmail.Content = ((Member)p).Email;
                txtMemberNr.Content = ((Member)p).MembershipNumber;
            }
        }
    }
}
