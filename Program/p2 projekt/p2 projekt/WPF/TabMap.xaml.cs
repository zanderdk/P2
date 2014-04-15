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
using System.Windows.Navigation;
using System.Windows.Shapes;



namespace p2_projekt.WPF
{
    /// <summary>
    /// Interaction logic for Map.xaml
    /// </summary>
    public partial class TabMap : UserControl
    {
        public TabMap()
        {
            InitializeComponent();

            
        }

        private void Rectangle_clicked(object sender, MouseButtonEventArgs e)
        {
            if ((sender as Rectangle).Fill == Brushes.Red) (sender as Rectangle).Fill = Brushes.Green;
            else (sender as Rectangle).Fill = Brushes.Red;
        }
    }
}
