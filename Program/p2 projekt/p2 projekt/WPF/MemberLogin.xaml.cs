using System.Windows;
using p2_projekt.controllers;

namespace p2_projekt.WPF
{
    /// <summary>
    /// Interaction logic for MemberLogin.xaml
    /// </summary>
    public partial class MemberLogin : Window
    {
        private LoginController controller;

        public MemberLogin()
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

        private void back_click(object sender, RoutedEventArgs e)
        {
            Standby chipLogin = new Standby();
            chipLogin.Show();
            Close();
        }
    }
}

