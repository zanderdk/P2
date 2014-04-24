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

namespace p2_projekt.WPF
{
    /// <summary>
    /// Interaction logic for ChipRequester.xaml
    /// </summary>
    public partial class ChipRequester : Window
    {
        public ChipRequester()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            loginscreen login = new loginscreen();
            login.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            GuestCreator newGuestCreator = new GuestCreator();
            newGuestCreator.Show();
            this.Close();
        }
        private void ChipNum_KeyUp(object sender, KeyEventArgs e) //Simluering af chiplæser PAS PÅ MED NULL-REFERENCES
        {
            if (e.Key == Key.Enter && !string.IsNullOrEmpty(ChipNum.Text))
            {
                UserController userController = Utilities.lobopDB;
                main main = new main(userController.Read<User>(x => x.UserId.ToString() == ChipNum.Text));
                main.Show();
                this.Close();
            }
        }
    }
}
