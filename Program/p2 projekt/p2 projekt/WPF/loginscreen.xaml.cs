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
using p2_projekt.controllers;

namespace p2_projekt.WPF
{
    /// <summary>
    /// Interaction logic for loginscreen.xaml
    /// </summary>
    public partial class loginscreen : Window
    {
        private LoginController controller;

        public loginscreen()
        {
            InitializeComponent();
            controller = new LoginController();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (controller.Validate(membernr.Text, password.Password))
            {
                Close();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ChipRequester ChipLogin = new ChipRequester();
            ChipLogin.Show();
            this.Close();
        }
    }
}

