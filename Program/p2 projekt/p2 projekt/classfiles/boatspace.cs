using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p2_projekt.classfiles
{
    abstract class Boatspace
    {
        int id;
        double length;
        double height;

        public Boat Boat { get; set; } //TODO get bikonjuktiv shit working

    }

    class Waterspace : Boatspace
    {

    }

    class Landspace : Boatspace
    {
    }
}
