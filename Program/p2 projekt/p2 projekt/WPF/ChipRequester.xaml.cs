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
using p2_projekt.controllers;

namespace p2_projekt.WPF
{
    /// <summary>
    /// Interaction logic for ChipRequester.xaml
    /// </summary>
    public partial class ChipRequester : Window
    {
        private LoginController controller;

        public ChipRequester()
        {
            InitializeComponent();
            controller = new LoginController();
            ChipNum.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Loginscreen login = new Loginscreen();
            login.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            GuestCreator newGuestCreator = new GuestCreator();
            newGuestCreator.Show();
            this.Close();
        }
        private void ChipNum_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && !string.IsNullOrEmpty(ChipNum.Text))
            {
                if (controller.Validate(ChipNum.Text))
                {
                    Close();
                }else{
                    MessageBox.Show("Bruger ikke fundet");
                }
            }
        }
    }
}
