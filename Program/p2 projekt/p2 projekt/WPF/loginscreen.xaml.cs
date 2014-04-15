﻿using System;
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
        
        User findUserByUsername(string username)
        {
            
            UserController userController = new UserController(new Utilities.Database());
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
            Console.WriteLine(u.Permission.MemberInfo);
            return u;
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            Member mb = new Member("Name", new CivicAddress("dfgdfgfdg", "dfgdfgdfg", "dfdfg", "dfdfggh", "dfgdg", "dfgdfg", "dfgdfg", "dfgdg"), 123);

            main main = new main(mb);
            main.Show();
            this.Close();


                //User u = findUserByUsername(membernr.Text);
                //if(u != null)
                //{   
                //    ILoginable loginable = (u as ILoginable);
                //    if (password.Password == loginable.Password)
                //    {
                //        main = new main(u);
                //        main.Show();
                //        this.Close();
                //    }
                //    else
                //    {
                //        MessageBox.Show("Forkert password.");
                //    }
                    
                //}
                //else
                //{
                //    MessageBox.Show("Bruger ikke fundet.");
                //}
        }
    }
}

