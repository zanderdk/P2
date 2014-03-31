using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Device.Location;
using System.ComponentModel.DataAnnotations;

namespace p2_projekt.models
{
    
    public abstract class Person
    {
        [Key]
        public int PersonId { get; set; }// Unique. Only used internally
                
        public List<Boat> boats; // boats owned

        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public CivicAddress Adress { get; set; }
        public bool IsActive { get; set; } // Still active in club

        public Permissions Permissions; // must be initialized with no access at all. E.g = new Permissions().LowestAccess;

        public Person()
        {
            
        }

        public Person(string name)
        {
            Name = name;
        }

    }
    
    public class Member : Person
    {
        public int MembershipNumber { get; private set; } // backwards compatible with existing numbers from Vestre Baadelaug database.

        public List<Travel> Travels { get; private set; } // All travels. Old and new.

        public Int64 Phone { get; set; }

        public string Email { get; set; }
        
        public Member() : base() { }

        public Member(string name, CivicAddress adress) : base(name)
        {
            Travels = new List<Travel>();
            Name = name;
            Adress = adress;
            // assign membership number
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
    }
    
    // has no member ID
    public class HarbourMaster : Person
    {
        
    }

    public class Guest : Person
    {

    }
}
