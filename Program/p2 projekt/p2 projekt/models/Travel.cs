using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace p2_projekt.models
{
    public class Travel : IEquatable<Travel>
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

        public bool Equals(Travel other)
        {
            if (this.Start.CompareTo(other.Start) == 0 && this.End.CompareTo(other.End) == 0) return true;
            else return false;
        }
    }
}
