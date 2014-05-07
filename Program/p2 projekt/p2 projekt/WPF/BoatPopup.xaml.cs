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
using System.Windows.Shapes;

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
            controller = new BoatController(Boat, Sailor, EnumOperation.Add);
        }

        public BoatPopup(Boat b)
        {
            Init();
            Boat = b;
            Sailor = (b.User as ISailor);

            DataContext = b;
            controller = new BoatController(Boat, Sailor, EnumOperation.Edit);
        }

        private void Init()
        {
            InitializeComponent();
        }

        private void Submit(object sender, RoutedEventArgs e)
        {
            controller.SubmitChanges();
            this.Close();
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            controller.ResetChanges();
            this.Close();
        }
    }
}
