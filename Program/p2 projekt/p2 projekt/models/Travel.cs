using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace p2_projekt.classfiles
{
    class Travel
    {
        public DateTime Start { get; set; } 
        public DateTime End { get; set; }

        public bool isActive { get; }// must change based on today
    }
}
