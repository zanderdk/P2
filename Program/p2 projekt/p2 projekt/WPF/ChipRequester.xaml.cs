using System.Windows;
using System.Windows.Input;
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
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            GuestCreator newGuestCreator = new GuestCreator();
            newGuestCreator.Show();
            Close();
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
