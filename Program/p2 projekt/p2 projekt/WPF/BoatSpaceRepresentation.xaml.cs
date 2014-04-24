using p2_projekt.controllers;
using p2_projekt.models;
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
    /// Interaction logic for BoatSpaceRepresentation.xaml
    /// </summary>
    public partial class BoatSpaceRepresentation : UserControl
    {
        public BoatSpace BoatSpace { get; set; }

        public Brush Fill {
            get
            {
                return Rectangle.Fill;
            }

            set 
            {
                Rectangle.Fill = value;
            }
        }

        

        public BoatSpaceRepresentation()
        {
            InitializeComponent();
        }

        private void BoatSpaceGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {

            // TODO går bare ind på brugeren der er på pladsen lige nu
            SearchController.main.selectUser(BoatSpace.Boat.User);
        }
    }
}
