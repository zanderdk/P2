﻿using p2_projekt.controllers;
using p2_projekt.Enums;
using p2_projekt.models;
using System.Windows;

namespace p2_projekt.WPF
{
    /// <summary>
    /// Interaction logic for SensorSimulator.xaml
    /// </summary>
    public partial class SensorSimulator : Window, IBoatSpaceSensor
    {
        public SensorSimulator()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BoatSpaceStatus status = BoatSpaceStatus.Empty;
            switch (statusDropdown.SelectedIndex)
            {
                case 0:
                    status = BoatSpaceStatus.GuestBoat;
                    break;
                case 1:
                    status = BoatSpaceStatus.Empty;
                    break;
                case 2:
                    status = BoatSpaceStatus.MemberBoat;
                    break;
                default:
                    MessageBox.Show("Ikke gyldig status");
                    return;
            }
            int id = int.Parse(boatSpaceId.Text);
            BoatSpace boatSpace = Utilities.LobopDB.Read<BoatSpace>(x => x.BoatSpaceId == id);
            if (boatSpace == null)
            {
                MessageBox.Show("bådplads ikke fundet");
            }
            else
            {
                ChangeStatus(boatSpace, status);
            }
        }

        public void ChangeStatus(BoatSpace bs, BoatSpaceStatus status)
        {
            bs.BoatSpaceStatus = status;
        }
    }
}
