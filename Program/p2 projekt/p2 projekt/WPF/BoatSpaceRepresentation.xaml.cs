using p2_projekt.controllers;
using p2_projekt.Enums;
using p2_projekt.models;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace p2_projekt.WPF
{
    /// <summary>
    /// Interaction logic for BoatSpaceRepresentation.xaml
    /// </summary>
    public partial class BoatSpaceRepresentation : UserControl
    {
        private BoatSpace _boatSpace;
        public BoatSpace BoatSpace {
            get { return _boatSpace; }
            set {
                _boatSpace = value;
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
                case BoatSpaceStatus.GuestBoat:
                    Fill = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                    break;
                case BoatSpaceStatus.Empty:
                    Fill = new SolidColorBrush(Color.FromRgb(0, 255, 0));
                    break;
                case BoatSpaceStatus.MemberBoat:
                    Fill = new SolidColorBrush(Color.FromRgb(255, 255, 0));
                    break;
            }
        }

        private void BoatSpaceGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if(BoatSpace.Boat != null) MainController.SelectUser(BoatSpace.Boat.User);
        }
    }
}
