﻿using System.ComponentModel;

namespace p2_projekt.models
{
    public class Boat : INotifyPropertyChanged
    {
        public Boat(){}

        public Boat(string name, double length, double width)
        {
            Name = name;
            Length = length;
            Width = width;
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { 
                _name = value;
                OnPropertyChanged("Name");
                }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public int BoatId { get; set; }

        public int UserId { get; set; }
        public virtual  User User { get; set; }

        private bool _spaceChange;
        private BoatSpace _space;


        public virtual  BoatSpace BoatSpace
        {
            get
            {
                return _space;
            }

            set
            {
                if (_spaceChange) return;

                BoatSpace oldspace = _space;
                _space = value;

                // Opdater gammel
                if (oldspace != null)
                {
                    _spaceChange = true;
                    oldspace.Boat = null;
                    _spaceChange = false;
                }

                // Opdater ny
                if (_space != null)
                {
                    _spaceChange = true;
                    _space.Boat = this;
                    _spaceChange = false;
                }
            }
        }
        public double Length { get; set; }
        public double Width { get; set; }
        public string RegistrationNumber { get; set; }

        public override bool Equals(object obj)
        {
            if(obj == null)
            {
                return false;
            }
            
            if(obj.GetType() != GetType())
            {
                return false;
            }

            return (obj as Boat).BoatId == BoatId;
        }

        public override int GetHashCode()
        {
            return BoatId.GetHashCode();
        }

        public static bool operator ==(Boat b1, Boat b2)
        {
            if(ReferenceEquals(b1, null))
            {
                if (ReferenceEquals(b2, null))
                    return true;
                return false;
            }
            return b1.Equals(b2);
        }

        public static bool operator !=(Boat b1, Boat b2)
        {
            return !(b1 == b2);
        }

        public override string ToString()
        {
            return string.Format("{0}", Name);
        }
    }
}
