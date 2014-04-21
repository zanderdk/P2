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
        
        User findUserByUsername(string username, UserController us)
        {
            UserController userController = us;
            //UserController userController = new UserController(new Utilities.Database());
            User u = userController.Read<User>( x=> {
                if(x is ILoginable)
                {
                    if((x as ILoginable).Username == username)
                    {
                        return true;
                    }
                }
                return false;
            });

            return u;
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            UserController us = new UserController(new Utilities.Database());
            User u = findUserByUsername(membernr.Text, us);
            if (u != null)
            {
                ILoginable loginable = (u as ILoginable);
                if (password.Password == loginable.Password)
                {
                    //main main = new main(u);
                    //main.Show();
                    //this.Close();
                    u.Name = "zander6";
                    us.Update(u);
                }
                else
                {
                    MessageBox.Show("Forkert password.");
                }

            }
            else
            {
                MessageBox.Show("Bruger ikke fundet.");
            }
        }

        private void password_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                Login_Click(sender, e);
            }
        }

        
    }
}

