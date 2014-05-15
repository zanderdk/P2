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
    public class BoatController : INotifyPropertyChanged
    {
        public BoatPopup Sender { get; set; }

        public readonly Operation _operation;
        private Boat _boat;
        public Boat Boat {
            get { return _boat; }
            set {
                NotifyPropertyChanged("Boat");
                _boat = value;}
            }
        public ISailor Sailor { get; set; }
        public BoatSpace SelectedBoatSpace { get; set; }
        public List<BoatSpace> BoatSpaces { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        private void init()
        {
            saveCommand = new SaveCommand(this);
            BoatSpaces = (List<BoatSpace>)Utilities.LobopDB.ReadAll<BoatSpace>(x => x.Boat == null);
            BoatSpaces.Add((new WaterSpace(0, 0) { Info = "Ingen Plads" }));
            if(_operation == Operation.Edit)
            {
                if(Boat.BoatSpace != null)
                {
                    BoatSpaces.Add(Boat.BoatSpace);
                    SelectedBoatSpace = Boat.BoatSpace;
                }
                else
                {
                    SelectedBoatSpace = BoatSpaces.Find(x => x.Info == "Ingen Plads");
                }
            }
            else
            {
                SelectedBoatSpace = BoatSpaces.Find(x => x.Info == "Ingen Plads");
            }
        }

        public BoatController(Boat b, BoatPopup bp)
        {
            Sender = bp;
            _operation = Operation.Edit;
            Boat = b;
            Sailor = b.User;
            init();
        }

        public BoatController(ISailor s, BoatPopup bp)
        {
            Sender = bp;
            _operation = Operation.Add;
            Boat = new Boat();
            Boat.User = s;
            Sailor = s;
            init();
        }

        

        public static void Delete(Boat b)
        {
            if (b != null)
            {
                b.User.Boats.Remove(b);
                DALController uc = Utilities.LobopDB;
                uc.Remove(b);
            }
        }

        public SaveCommand saveCommand { get; set; }

    }

    public class SaveCommand : ICommand
    {
        private BoatController _controller;
        public SaveCommand(BoatController sender)
        {
            _controller = sender;
        }

        public bool CanExecute(object parameter)
        {
            
            if(_controller.Boat.Name == "" || _controller.Boat.Name == null || _controller.Boat.Length < 1 || _controller.Boat.Width < 1 || _controller.Boat.RegistrationNumber == "" || _controller.Boat.RegistrationNumber == null)
                return false;

            return true;
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
            if(_controller._operation == Operation.Add)
            {
                if(_controller.SelectedBoatSpace.Info == "Ingen Plads")
                {
                    _controller.Boat.BoatSpace = null;
                }
                else
                {
                    _controller.Boat.BoatSpace = _controller.SelectedBoatSpace;
                }
                _controller.Sailor.Boats.Add(_controller.Boat);
                Utilities.LobopDB.Update<User>(_controller.Sailor as User);
            }
            else
            {
                if(_controller.Sailor is Guest)
                {
                    if(_controller.SelectedBoatSpace != null)
                    {
                        _controller.SelectedBoatSpace.BoatSpaceStatus = BoatSpaceStatus.GuestBoat;
                    }
                    _controller.Sender.Close();
                    return;
                }

                if (_controller.SelectedBoatSpace.Info == "Ingen Plads")
                {
                    _controller.Boat.BoatSpace.Boat = null;
                    _controller.Boat.BoatSpace = null;
                }
                else
                {
                    _controller.Boat.BoatSpace = _controller.SelectedBoatSpace;
                }
                Utilities.LobopDB.Update(_controller.Boat);
            }

            _controller.Sender.Close();
        }
    }

}
