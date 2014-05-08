using p2_projekt.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using p2_projekt.controllers;

namespace p2_projekt.WPF
{
    public class MemberInfoController : INotifyPropertyChanged
    {
        private User user;
        private Boat boat;
        private Travel travel;

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public MemberInfoController(User user)
        {
            User = user;
            addBoatCommand = new AddBoatCommand(user);
            changeBoatCommand = new ChangeBoatCommand(this);
            removeBoatCommand = new RemoveBoatCommand(this);

            addTravelCommand = new AddTravelCommand(user);
            
            

            addUserCommand = new AddUserCommand();
            changeUserCommand = new ChangeUserCommand(user);
            removeUserCommand = new RemoveUserCommand(user);
        }

        public String Birthday { 
            get { 
                return User is IFullPersonalInfo ? (User as IFullPersonalInfo).Birthday.ToString("dd/MM/yyyy") : ""; 
            } 
        }

        public User User
        {
            get { return user; }
            set { user = value;
            NotifyPropertyChanged("User");
            }
        }

        public Boat Boat
        {
            get { return boat; }
            set { boat = value;
            NotifyPropertyChanged("Boat");
            }
        }

        public Travel Travel
        {
            get { return travel; }
            set { travel = value;
            NotifyPropertyChanged("Travel");
            }
        }

        public AddTravelCommand addTravelCommand { get; private set; }
        public AddBoatCommand addBoatCommand { get; private set; }
        public ChangeBoatCommand changeBoatCommand { get; private set; }
        public RemoveBoatCommand removeBoatCommand { get; private set; }
        public AddUserCommand addUserCommand { get; private set; }
        public ChangeUserCommand changeUserCommand { get; private set; }
        public RemoveUserCommand removeUserCommand { get; private set; }
    }

    public class AddBoatCommand : ICommand
    {
        private User user;
        public AddBoatCommand(User s)
        {
            user = s;
        }

        public bool CanExecute(object parameter)
        {
            if (!(user is ISailor))
                return false;

            if (user == Main.loggedIn)
                return Permission.CanWrite(user.Permission.PersonalInfo);
            else
                return Permission.CanWrite(Main.loggedIn.Permission.OtherUsers);
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            new BoatPopup(user as ISailor).Show();
        }
    }

    public class RemoveBoatCommand : ICommand
    {
        private User user { get { return change.User; } }
        private Boat boat
        {
            get
            {
                if (user != null)
                    return change.Boat;

                return null;
            }
        }

        private MemberInfoController change;
        public RemoveBoatCommand(MemberInfoController sender)
        {
            change = sender;
        }

        public bool CanExecute(object parameter)
        {
            if (boat == null)
                return false;

            if (!(user is ISailor))
                return false;

            if (user == Main.loggedIn)
                return Permission.CanWrite(user.Permission.PersonalInfo);
            else
                return Permission.CanWrite(Main.loggedIn.Permission.OtherUsers);
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
            BoatController.Delete(boat);
        }
    }

    public class ChangeBoatCommand : ICommand
    {
        private User user { get { return change.User; } }
        private Boat boat { get {
            if (user != null)
                return change.Boat;

            return null;
        } }

        private MemberInfoController change;
        public ChangeBoatCommand(MemberInfoController sender)
        {
            change = sender;
        }

        public bool CanExecute(object parameter)
        {
            if (boat == null)
                return false;

            if (!(user is ISailor))
                return false;

            if (user == Main.loggedIn)
                return Permission.CanWrite(user.Permission.PersonalInfo);
            else
                return Permission.CanWrite(Main.loggedIn.Permission.OtherUsers);
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
            new BoatPopup(boat).Show();
        }
    }

    public class RemoveUserCommand : ICommand
    {
        private User user;
        public RemoveUserCommand(User u)
        {
            user = u;
        }
        public bool CanExecute(object parameter)
        {
            if (user == Main.loggedIn)
                return false;

            return Permission.CanWrite(Main.loggedIn.Permission.OtherUsers);
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            Utilities.LobopDB.Remove(user);
            System.Windows.Forms.MessageBox.Show("bruger fjernet.");
        }
    }

    public class AddUserCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return Permission.CanWrite(Main.loggedIn.Permission.OtherUsers);
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            new memberCreator().Show();
        }
    }

    public class ChangeUserCommand : ICommand
    {
        private User user;

        public ChangeUserCommand(User u)
        {
            user = u;
        }

        public bool CanExecute(object parameter)
        {
            if(user == Main.loggedIn)
            {
                return (Permission.CanWrite(user.Permission.PersonalInfo));
            }
            else
            {
                return (Permission.CanWrite(Main.loggedIn.Permission.OtherUsers));
            }
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            new memberCreator(user).Show();
        }
    }



    public class AddTravelCommand : ICommand
    {
        private User user;
        public AddTravelCommand(User s)
        {
            user = s;
        }

        public bool CanExecute(object parameter)
        {
            if (user == Main.loggedIn)
                return Permission.CanWrite(user.Permission.PersonalInfo);
            else
                return Permission.CanWrite(Main.loggedIn.Permission.OtherUsers);
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            new TravelPopup(user as ISailor).Show();
        }
    }
}
