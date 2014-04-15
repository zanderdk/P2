using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace p2_projekt.models
{
    public class Travel : IEquatable<Travel>
    {
        public Travel() { }
        public int TravelId { get; set; }
        public DateTime Start { get; set; } 
        public DateTime End { get; set; }
        public bool isActive { get { return true; } }// TODO must change based on today
        public User User { get; set; }

        public Travel(DateTime start, DateTime end)
        {
            // TODO: Complete member initialization
            this.Start = start;
            this.End = end;
        }

        public override int GetHashCode()
        {
            int first = (Start == null ? 0 : Start.GetHashCode());
            int second = (End == null ? 0 : End.GetHashCode());
            int third = TravelId.GetHashCode();
            return first ^ second ^ third;
        }
        
       public bool Equals(Travel other)
        {
           if (other == null)
           {
                return false;
           }

           if (Travel.ReferenceEquals(this, other))
           {
               return true;
           }

           if(GetHashCode() != other.GetHashCode())
           {
               return false;
           }
                     
           return this.Start.Equals(other.Start) && this.End.Equals(other.End);
        }

    }
}
