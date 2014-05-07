using System;
using System.ComponentModel;
using System.Windows.Input;
using p2_projekt.models;
using p2_projekt.WPF;

namespace p2_projekt.controllers
{
    class MemberInfoController : INotifyPropertyChanged
    {
        private User _user;
        private Boat _boat;
        private Travel _travel;

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
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
            changeBoatCommand = new ChangeBoatCommand(_boat, this);
            removeBoatCommand = new RemoveBoatCommand(_boat);

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
            get { return _user; }
            set { _user = value; }
        }

        public Boat Boat
        {
            get { return _boat; }
            set { _boat = value;
            NotifyPropertyChanged("Boat");
            }
        }

        public Travel Travel
        {
            get { return _travel; }
            set { _travel = value; }
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

            if (user == Main.LoggedIn)
                return Permission.CanWrite(user.Permission.PersonalInfo);
            else
                return Permission.CanWrite(Main.LoggedIn.Permission.OtherUsers);
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            new BoatPopup(user as ISailor).Show();
        }
    }

    public class RemoveBoatCommand : ICommand
    {
        private User user;
        private Boat boat;
        public RemoveBoatCommand(Boat b)
        {
            boat = b;
            if (b != null)
                user = b.User;
        }

        public bool CanExecute(object parameter)
        {
            if (!(user is ISailor))
                return false;

            if (boat == null)
                return false;

            if (user == Main.LoggedIn)
                return Permission.CanWrite(user.Permission.PersonalInfo);
            else
                return Permission.CanWrite(Main.LoggedIn.Permission.OtherUsers);
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            BoatController.Delete(boat);
        }
    }

    public class ChangeBoatCommand : ICommand
    {
        private User user;
        private Boat boat;

        void Call(object sender, EventArgs arg)
        {
            CanExecute(null);
        }

        public ChangeBoatCommand(Boat b, INotifyPropertyChanged sender)
        {
            sender.PropertyChanged += this.Call;
            boat = b;
            if(b != null)
                user = b.User;
        }

        public bool CanExecute(object parameter)
        {
            if (boat == null)
                return false;

            if ((user is ISailor))
                return false;

            if (user == Main.LoggedIn)
                return Permission.CanWrite(user.Permission.PersonalInfo);
            else
                return Permission.CanWrite(Main.LoggedIn.Permission.OtherUsers);
        }

        public event EventHandler CanExecuteChanged;

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
            if (user == Main.LoggedIn)
                return false;

            return Permission.CanWrite(Main.LoggedIn.Permission.OtherUsers);
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
            return Permission.CanWrite(Main.LoggedIn.Permission.OtherUsers);
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            new MemberCreator().Show();
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
            if(user == Main.LoggedIn)
            {
                return (Permission.CanWrite(user.Permission.PersonalInfo));
            }
            else
            {
                return (Permission.CanWrite(Main.LoggedIn.Permission.OtherUsers));
            }
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            new MemberCreator(user).Show();
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
            if (user == Main.LoggedIn)
                return Permission.CanWrite(user.Permission.PersonalInfo);
            else
                return Permission.CanWrite(Main.LoggedIn.Permission.OtherUsers);
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            new TravelPopup(user as ISailor).Show();
        }
    }
}
