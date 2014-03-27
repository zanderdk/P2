using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace p2_projekt.models
{
    public class Travel
    {
        public DateTime Start { get; set; } 
        public DateTime End { get; set; }

        public bool isActive { get { return true; } }// must change based on today

        public Travel(DateTime start, DateTime end)
        {
            // TODO: Complete member initialization
            this.Start = start;
            this.End = end;
        }
    }
}
