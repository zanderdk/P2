using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace p2_projekt.models
{
    public class Travel : IEquatable<Travel>, INotifyPropertyChanged
    {
        public Travel() { }
        public int TravelId { get; set; }
        private DateTime _Start;
        public DateTime Start { get { return _Start; }
            set {
                _Start = value;
                OnPropertyChanged("Start");
            }
        }

        private DateTime _End;
        public DateTime End
        {
            get { return _End; }
            set
            {
                _End = value;
                OnPropertyChanged("End");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool isActive 
        { 
            get 
            {
                if (Start < DateTime.Now && End > DateTime.Now) return true;
                else return false;
            }
        }

        public virtual ISailor User { get; set; }

        public Travel(DateTime start, DateTime end)
        {
            // TODO: Complete member initialization
            this.Start = start;
            this.End = end;
        }

        public override int GetHashCode()
        {
            int first = (Start == null ? 0 : Start.GetHashCode());
            int second = (End == null ? 0 : End.GetHashCode());
            int third = TravelId.GetHashCode();
            return first ^ second ^ third;
        }
        
        public bool Equals(Travel other)
        {
            if (other == null)
            {
                return false;
            }

            if (Travel.ReferenceEquals(this, other))
            {
                return true;
            }

            if(GetHashCode() != other.GetHashCode())
            {
                return false;
            }
                     
            return this.Start.Equals(other.Start) && this.End.Equals(other.End);
        }

        public override string ToString()
        {
            return string.Format("Udrejse: {0} Hjemkomst: {1}", this.Start, this.End );
        }
    }
}
