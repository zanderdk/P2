using p2_projekt.controllers;
using p2_projekt.Enums;
using p2_projekt.models;
using System.Windows;

namespace p2_projekt.WPF
{
    public partial class BoatPopup : Window
    {
        private Boat Boat;
        private ISailor Sailor;
        private BoatController controller;
        

        public BoatPopup(ISailor s)
        {
            Init();
            Sailor = s;
            Boat = new Boat();
            Boat.User = Sailor as User;

            DataContext = Boat;
            controller = new BoatController(Boat, Sailor, Operation.Add);
        }

        public BoatPopup(Boat b)
        {
            Init();
            Boat = b;
            Sailor = (b.User as ISailor);

            DataContext = b;
            controller = new BoatController(Boat, Sailor, Operation.Edit);
        }

        private void Init()
        {
            InitializeComponent();
        }

        private void Submit(object sender, RoutedEventArgs e)
        {
            controller.SubmitChanges();
            Close();
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            controller.ResetChanges();
            Close();
        }
    }
}
