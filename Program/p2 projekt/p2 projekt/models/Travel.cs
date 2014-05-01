using System;
using System.ComponentModel;

namespace p2_projekt.models
{
    public class Travel : IEquatable<Travel>, INotifyPropertyChanged
    {
        public Travel() { }
        public int TravelId { get; set; }
        private DateTime _start;
        public DateTime Start { get { return _start; }
            set {
                _start = value;
                OnPropertyChanged("Start");
            }
        }

        private DateTime _end;
        public DateTime End
        {
            get { return _end; }
            set
            {
                _end = value;
                OnPropertyChanged("End");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool IsActive 
        { 
            get
            {
                if (Start < DateTime.Now && End > DateTime.Now) return true;
                return false;
            }
        }

        public virtual ISailor User { get; set; }

        public Travel(DateTime start, DateTime end)
        {
            // TODO: Complete member initialization
            Start = start;
            End = end;
        }

        public override int GetHashCode()
        {
            int first = (Start.GetHashCode());
            int second = (End.GetHashCode());
            int third = TravelId.GetHashCode();
            return first ^ second ^ third;
        }
        
        public bool Equals(Travel other)
        {
            if (other == null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if(GetHashCode() != other.GetHashCode())
            {
                return false;
            }
                     
            return Start.Equals(other.Start) && End.Equals(other.End);
        }

        public override string ToString()
        {
            return string.Format("Udrejse: {0} Hjemkomst: {1}", Start.ToString("dd/MM/yyyy"), End.ToString("dd/MM/yyyy"));
        }
    }
}
