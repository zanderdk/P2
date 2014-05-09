using p2_projekt.Enums;
using p2_projekt.models;
using System.Windows;
using System;
using System.ComponentModel;
using System.Windows.Input;
using p2_projekt.WPF;
using System.Windows.Data;
using System.Collections;
using System.Collections.Generic;

namespace p2_projekt.controllers
{
    public class BoatSpaceController : INotifyPropertyChanged
    {
        private BoatSpace _boatSpace;

        public BoatSpacePopup Sender { get; set; }
        public BoatSpace BoatSpace { get { return _boatSpace; } set { NotifyPropertyChanged("BoatSpace"); _boatSpace = value; } }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public BoatSpaceController(BoatSpace bs, BoatSpacePopup bsp)
        {
            Sender = bsp;   
            BoatSpace = bs;
            boatSpaceSaveCommand = new BoatSpaceSaveCommand(this);
        }

        public BoatSpaceSaveCommand boatSpaceSaveCommand { get; set; }

    }


    public class BoatSpaceSaveCommand : ICommand
    {
        private BoatSpaceController _controller;
        public BoatSpaceSaveCommand(BoatSpaceController sender)
        {
            _controller = sender;
        }

        public bool CanExecute(object parameter)
        {
            return (_controller.Sender.Length.Text != "" && _controller.Sender.Width.Text != "" && _controller.Sender.Info.Text != "");
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public void RaiseCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }

        public void Execute(object parameter)
        {
            Utilities.LobopDB.Update(_controller.BoatSpace);
            _controller.Sender.Close();
        }

    }
}
