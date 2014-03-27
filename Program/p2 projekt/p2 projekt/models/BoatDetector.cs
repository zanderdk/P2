using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p2_projekt.models
{
    public static class BoatDetector
    {
        public enum BoatStatus { Member, Guest, Empty};
        public static BoatStatus BoatAt(WaterSpace space)
        {
            return BoatStatus.Empty;
        }
    }
}
