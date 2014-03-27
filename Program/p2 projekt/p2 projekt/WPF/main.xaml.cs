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
    /// Interaction logic for main.xaml
    /// </summary>
    public partial class main : Window
    {
        public main(Person person)
        {
            InitializeComponent();
            if (!person.Permissions.canWritePersons)
            {
                TabItem tab = (TabItem)tabControler.Items[1];
                tab.Visibility = System.Windows.Visibility.Hidden;
            }

            if (!person.Permissions.canSearchPersons)
            {
                TabItem tab = (TabItem)tabControler.Items[0];
                tab.Visibility = System.Windows.Visibility.Hidden;
            }
        }

    }
}
