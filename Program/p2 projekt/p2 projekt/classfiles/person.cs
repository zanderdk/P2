using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Device.Location;

namespace p2_projekt.classfiles
{
    abstract class Person
    {
        public abstract int Id { get; }
                
        public List<Boat> boats;

        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public CivicAddress Adress { get; set; }

        public Person(string name)
        {
            Name = name;
        }

    }
    
    class Member : Person
    {
        public int Id { get; set; }

        public int Membership { get; set; }
              
        public Member(string name, CivicAddress adress) : base(name)
        {
            
        }
    }

    class Guest : Person
    {
        public int Id { get; set; }

    }
}
