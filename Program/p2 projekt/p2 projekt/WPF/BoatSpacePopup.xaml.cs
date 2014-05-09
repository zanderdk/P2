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
using p2_projekt.controllers;
using p2_projekt.models;

namespace p2_projekt.WPF
{
    /// <summary>
    /// Interaction logic for BoatSpacePopup.xaml
    /// </summary>
    public partial class BoatSpacePopup : Window
    {
        public BoatSpacePopup(BoatSpace bs)
        {
            InitializeComponent();
            DataContext = new BoatSpaceController(bs, this);
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
