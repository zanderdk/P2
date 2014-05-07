using System.Windows;
using p2_projekt.controllers;

namespace p2_projekt.WPF
{
    /// <summary>
    /// Interaction logic for Loginscreen.xaml
    /// </summary>
    public partial class Loginscreen : Window
    {
        private LoginController controller;

        public Loginscreen()
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
            ChipRequester chipLogin = new ChipRequester();
            chipLogin.Show();
            Close();
        }
    }
}

