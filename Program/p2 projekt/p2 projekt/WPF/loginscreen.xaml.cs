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
            HarbourMaster har = new HarbourMaster();
            har.Permissions = new Permissions() { member = Permissions.permissionTo.write };
            main main = new main(har);// fix shit
        }
    }
}
