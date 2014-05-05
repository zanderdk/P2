using p2_projekt.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace p2_projekt.WPF
{
    class MemberInfoViewModel : INotifyPropertyChanged
    {
        private User user;
        private Boat boat;
        private Travel travel;

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public MemberInfoViewModel(User user)
        {
            User = user;
            addBoatCommand = new AddBoatCommand(user);
            addTravelCommand = new AddTravelCommand(user);
        }

        public String Birthday { 
            get { 
                return User is IFullPersonalInfo ? (User as IFullPersonalInfo).Birthday.ToString("dd/MM/yyyy") : ""; 
            } 
        }

        public User User
        {
            get { return user; }
            set { user = value; }
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
            set { travel = value; }
        }

        public AddTravelCommand addTravelCommand { get; private set; }
        public AddBoatCommand addBoatCommand { get; private set; }
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
            return user is Member;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            new BoatPopup(user as ISailor).Show();
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
            return user is Member;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            new TravelPopup(user as ISailor).Show();
        }
    }
}
