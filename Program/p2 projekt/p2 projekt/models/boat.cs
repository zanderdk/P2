using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p2_projekt.models
{
    public class Boat
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Person Owner { get; set; }
        public BoatSpace Space { get; set; } //TODO get bikonjuktiv shit working
        public double Lenght { get; set; }
        public double Widht { get; set; }

    }
}
