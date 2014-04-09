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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Member Andreas = new Member() { 
                Name = "Andreas Hansen", 
                UserId = 12653, 
                Adress = new CivicAddress() {
                    AddressLine1 = "Bobstreet 5", 
                    PostalCode = "1337", 
                    CountryRegion = "Fyn"
                }, 
                Boats = new List<Boat>() {
                    new Boat() {                    
                        Lenght = 5, 
                        Width = 10, 
                        Name = "The Bertha"
                    }
                }
            };
            Andreas.Permissions = new Permissions() { member = true, readOnlyMember = true };


            main main = new main(Andreas);
            main.Show();
            this.Close();
        }
    }

}

