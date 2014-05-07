using System;
using System.Windows;
using p2_projekt.Enums;
using p2_projekt.models;
using p2_projekt.controllers;

namespace p2_projekt.WPF
{
    /// <summary>
    /// Interaction logic for TravelAddPopup.xaml
    /// </summary>
    public partial class TravelPopup : Window
    {
/*
        private Travel tempTravel;
*/

        private TravelController controller;

        public TravelPopup(ISailor sailor)
        {
            Init();
            ISailor sailor1 = sailor;
            Travel travel = new Travel(DateTime.Now, DateTime.Now);
            controller = new TravelController(travel, sailor, Operation.Add);
            Title = "Tilføj rejse";
            DataContext = travel;
        }

        private void Init(){
            InitializeComponent();
        }

        /// <summary>
        /// Edit travel constructor
        /// </summary>
        /// <param name="t"></param>
        public TravelPopup(Travel t, ISailor s)
        {
            Init();
            DataContext = t;
            Title = "Redigér rejse";
            controller = new TravelController(t, s, Operation.Edit);
        }


        private void Submit(object sender, RoutedEventArgs e)
        {
            if (controller.SubmitChanges())
            {
                this.Close();
            }
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            controller.ResetChanges();
            this.Close();
        }
    }
}
