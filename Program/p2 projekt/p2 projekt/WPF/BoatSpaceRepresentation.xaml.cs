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
        private BoatSpace boatSpace;
        public BoatSpace BoatSpace {
            get { return boatSpace; }
            set {
                boatSpace = value;
                BoatSpace.OnBoatSpaceChange += BoatSpace_OnBoatSpaceChange;
            }
        }

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

        void BoatSpace_OnBoatSpaceChange(object sender, BoatSpaceArgs e)
        {
            switch (e.Status)
            {
                case EnumBoatSpaceStatus.GuestBoat:
                    Fill = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                    break;
                case EnumBoatSpaceStatus.Empty:
                    Fill = new SolidColorBrush(Color.FromRgb(0, 255, 0));
                    break;
                case EnumBoatSpaceStatus.MemberBoat:
                    Fill = new SolidColorBrush(Color.FromRgb(255, 255, 0));
                    break;
            }
        }

        private void BoatSpaceGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if(BoatSpace.Boat != null) MainController.selectUser(BoatSpace.Boat.User);
        }
    }
}
