using p2_projekt.controllers;
using System;
using System.Collections.ObjectModel;
using System.Device.Location;

namespace p2_projekt.models
{
    public class Member : User, IFullPersonalInfo, ISailor, ILoginable
    {
        public int MembershipNumber { get; private set; } // backwards compatible with existing numbers from Vestre Baadelaug database.
        //public ObservableCollection<Travel> Travels { get; private set; } // All travels. Old and new.
        public bool IsActive { get; set; } // Still active in club

        public DateTime RegistrationDate { get; set; }
        public string MembershipDuration { get { return (DateTime.Now - RegistrationDate).ToString(); } } //TODO calculate shit

        private string _username;

        public string Username
        {
            get
            {
                if (_username != null) return _username;

                return MembershipNumber.ToString();
            }
            set
            {
                _username = value;
            }
        }

        public Member(string name, CivicAddress adress, int membershipNumber)
            : base(name)
        {
            Adress = adress;
            MembershipNumber = membershipNumber;
            Travels = new ObservableCollection<Travel>();
            Boats = new ObservableCollection<Boat>();
            RegistrationDate = DateTime.Now;
            IsActive = true;
        }

        public Member()
        {
            //only used by Entity framework
        }

        public Member(string name, CivicAddress adress)
            : this(name, adress, MainController.GetNextMemberShipNumber())
        {

        }

        public void AddNewTravel(DateTime start, DateTime end)
        {
            Travel travel = new Travel(start, end);
            Travels.Add(travel);
        }

        public void RemoveTravel(int index)
        {
            Travels.RemoveAt(index);
        }

        public void EditTravel(int index, DateTime newStart, DateTime newEnd)
        {
            Travel travel = new Travel(newStart, newEnd);
            Travels[index] = travel;
        }

        //TODO simon: skal denne ikke være private? vi skal ikke give al info væk. Det skal gå gennem addnewtravel osv.
        public virtual ObservableCollection<Travel> Travels
        {
            get;
            set;
        }

        public virtual ObservableCollection<Boat> Boats
        {
            get;
            set;
        }

        public string Email
        {
            get;
            set;
        }

        public DateTime Birthday
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (!(obj is Member))
            {
                return false;
            }

            return (obj as Member).MembershipNumber == MembershipNumber;
        }

        public override int GetHashCode()
        {
            return MembershipNumber.GetHashCode();
        }

        public static bool operator ==(Member u1, Member u2)
        {
            if (ReferenceEquals(u1, null))
            {
                if (ReferenceEquals(u2, null))
                    return true;
                return false;
            }
            return u1.Equals(u2);
        }

        public static bool operator !=(Member u1, Member u2)
        {
            return !(u1 == u2);
        }

        public override string ToString()
        {
            return string.Format("{0}", Name);
        }
    }
}
