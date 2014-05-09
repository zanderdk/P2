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
            if (_boatSpace == null)
                return;

            if(Permission.CanRead(Main.LoggedIn.Permission.OtherUsers))
                MainController.SelectUser(BoatSpace.Boat.User);


            if (Main.LoggedIn is ISailor)
            {
                bool flag = false;

                foreach(Boat b in (Main.LoggedIn as ISailor).Boats)
                {
                    if(b.BoatSpace == _boatSpace)
                    {
                        flag = true;
                        break;
                    }
                }

                if(flag && Permission.CanRead(Main.LoggedIn.Permission.PersonalInfo))
                {
                    MainController.SelectUser(BoatSpace.Boat.User);
                }
            }
        }

        private void BoatSpaceGrid_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            if(Permission.CanWrite(Main.LoggedIn.Permission.Map))
                new BoatSpacePopup(_boatSpace).Show();  
        }
    }
}
