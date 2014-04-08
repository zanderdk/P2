﻿using System;
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
    /// <summary>
    /// Interaction logic for ChipRequester.xaml
    /// </summary>
    public partial class ChipRequester : Window
    {
        public ChipRequester()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            loginscreen login = new loginscreen();
            login.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            GuestCreator newGuestCreator = new GuestCreator();
            newGuestCreator.Show();
            this.Close();
        }
    }
}
