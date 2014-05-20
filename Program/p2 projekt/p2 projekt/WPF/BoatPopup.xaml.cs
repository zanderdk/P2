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
        private BoatController _controller;

        public BoatPopup(ISailor s)
        {
            Init();
            _controller = new BoatController(s, this);
            DataContext = _controller;
        }

        public BoatPopup(Boat b)
        {
            Init();
            _controller = new BoatController(b, this);
            DataContext = _controller;
        }

        private void Init()
        {
            InitializeComponent();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            _controller.Reset();
            this.Close();
        }
    }
}
