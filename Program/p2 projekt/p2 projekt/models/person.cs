using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Device.Location;
using p2_projekt.classfiles;

namespace p2_projekt.models
{
    class Permissions{
        bool canReadEvent = false;
        // add more...
    }
    abstract class Person
    {
        private int Id { get; set; }// Unique. Only used internally
                
        public List<Boat> boats; // boats owned

        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public CivicAddress Adress { get; set; }
        public bool IsActive { get; set; } // Still active in club

        public Permissions Permissions; // must be initialized with no access at all. E.g = new Permissions().LowestAccess;

        public Person(string name)
        {
            Name = name;
        }

        public Person()
        {

        }

    }
    
    class Member : Person
    {

        public int MembershipNumber { get; private set; } // backwards compatible with existing numbers from Vestre Baadelaug database.

        public List<Travel> Travels { get; set; } // All travels. Old and new.
        
        public Member(string name, CivicAddress adress) : base(name)
        {
            // assign membership number
        }

        public void addNewTravel(DateTime start, DateTime end)
        {
            Travel travel = new Travel(start, end);
            Travels.Add(travel);
        }
    }
    
    // has no member ID
    class HarbourMaster : Person
    {
        
    }

    class Guest : Person
    {

    }
}
