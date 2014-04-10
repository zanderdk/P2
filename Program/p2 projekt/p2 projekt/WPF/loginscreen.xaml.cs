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

        public loginscreen()
        {
            InitializeComponent();
              
        }
        
        User findUserByNumber(int MemebershipNumber)
        {
            
            UserController userController = new UserController(new Utilities.Database());
            User u = userController.Read<User>( x=> {
                if(x is Member)
                {
                    if((x as Member).MembershipNumber == MemebershipNumber)
                    {
                        return true;
                    }
                }
                return false;
            });
            return u;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int number;
            if(int.TryParse(membernr.Text, out number))
            {
                User u = findUserByNumber(number);
                if(u != null)
                {
                    if(u is ILoginable)
                    {
                        ILoginable log = (u as ILoginable);
                        if (password.Password == log.Password)
                        {
                            main main = new main(u);
                            main.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Forkert password.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Brugeren har ikke regtighed til at logge ind.");
                    }
                }
                else
                {
                    MessageBox.Show("Bruger ikke fundet.");
                }
            }
            else { MessageBox.Show("Uglydigt Medlemsnummer."); }

        }
    }

}

