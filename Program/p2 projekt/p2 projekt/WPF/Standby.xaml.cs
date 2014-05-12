using System.Windows;
using System.Windows.Input;
using p2_projekt.controllers;
using p2_projekt.Interfaces;

namespace p2_projekt.WPF
{
    /// <summary>
    /// Interaction logic for Standby.xaml
    /// </summary>
    public partial class Standby : Window, IChipReader
    {
        private LoginController controller;

        public Standby()
        {
            InitializeComponent();
            controller = new LoginController();
            ChipNum.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MemberLogin login = new MemberLogin();
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
            if (e.Key == Key.Enter && !string.IsNullOrEmpty(Read()))
            {
                if (controller.Validate(ChipNum.Text))
                {
                    Close();
                }else{
                    MessageBox.Show("Bruger ikke fundet");
                }
            }
        }

        public string Read()
        {
            return ChipNum.Text;
        }
    }
}
