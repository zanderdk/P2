﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Device.Location;
using System.ComponentModel.DataAnnotations;

namespace p2_projekt.models
{
    
    public abstract class User
    {
        public int UserId { get; set; }// Unique. Only used internally
        //public Int64 Phone { get; set; }
        //public List<Boat> boats; // boats owned
        //public string Name { get; set; }

        public Permissions Permissions; // must be initialized with no access at all. E.g = new Permissions().LowestAccess;

        public User()
        {
            Permissions = new Permissions();
            //boats = new List<Boat>();
        }

        public User(string name) : this()
        {
            Name = name;
        }


        public string Phone
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public CivicAddress Adress
        {
            get;
            set;
        }

        public override string ToString()
        {
            return string.Format("{0} - {1} - {2}", this.Name, this.Phone, this.Adress.AddressLine1);
        }
    }

    public interface ILoginable
    {
        string Username { get; set; }
        string Password { get; set; }
    }

    public interface IFullPersonalInfo
    {
        string Email { get; set; }
        DateTime Birthday { get; set; }
        DateTime RegistrationDate { get; set; } //TODO automatisk registrering kun getter
        TimeSpan MebershipDuration { get; set; } //TODO calculate shit

    }

    public interface IBasicPersonalInfo
    {
        string Phone { get; set; }
        string Name { get; set; }
        CivicAddress Adress { get; set; }
    }

    public interface ISailor
    {
        List<Travel> Travels { get; set; } // All travels. Old and new.
        List<Boat> Boats {get; set;} // boats owned
    }
    
    
    public class Member : User, IFullPersonalInfo, ISailor, ILoginable
    {
        public int MembershipNumber { get; private set; } // backwards compatible with existing numbers from Vestre Baadelaug database.
        //public List<Travel> Travels { get; private set; } // All travels. Old and new.
        public bool IsActive { get; set; } // Still active in club
        //public string Email { get; set; }
        //public CivicAddress Adress { get; set; }
        //public DateTime Birthday { get; set; }

        public DateTime RegistrationDate { get; set; } //TODO automatisk registrering kun getter
        public TimeSpan MebershipDuration { get; set; } //TODO calculate shit

        private string _username;

        public string Username 
        { 
            get { 
                if (_username != null) return _username; return MembershipNumber.ToString(); 
            } 
            set {
                _username = value;
            }}

        public Member(string name, CivicAddress adress, int memerShipNumer)
        {
            Name = name;
            Adress = adress;
            MembershipNumber = memerShipNumer;
            Travels = new List<Travel>();
            Boats = new List<Boat>();
        }

        public Member() : base() {
            //only used by Entity framework
        }

        public Member(string name, CivicAddress adress) : this(name, adress, Utilities.GetNextMembershipNumber())
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

        // TODO simon: skal denne ikke være private? vi skal ikke give al info væk. Det skal gå gennem addnewtravel osv.
        public virtual List<Travel> Travels
        {
            get;
            set;
        }

        public virtual List<Boat> Boats
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
    }
    
    // has no member ID
    public class HarbourMaster : User, IFullPersonalInfo, ILoginable
    {

        public string Username { get; set; }

        public string Password { get; set; }

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

        public DateTime RegistrationDate { get; set; } //TODO automatisk registrering kun getter
        public TimeSpan MebershipDuration { get; set; } //TODO calculate shit

    }

    public class Guest : User, ISailor
    {
        public bool hasPaid { get; set; } //TODO Overvej at flytte denne til ny interface f.eks. IRenter

        public List<Travel> Travels
        {
            get;
            set;
        }

        public List<Boat> Boats
        {
            get;
            set;
        }
    }
}
