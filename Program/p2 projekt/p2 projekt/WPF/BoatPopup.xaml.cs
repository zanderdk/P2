using p2_projekt.controllers;
using p2_projekt.Enums;
using p2_projekt.models;
using System.Windows;
using System.Collections.Generic;
using System.Collections;

namespace p2_projekt.WPF
{
    public partial class BoatPopup : Window
    {
        public BoatPopup(ISailor s)
        {
            Init();
            DataContext = new BoatController(s, this);
        }

        public BoatPopup(Boat b)
        {
            Init();
            DataContext = new BoatController(b, this);
        }

        private void Init()
        {
            InitializeComponent();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
