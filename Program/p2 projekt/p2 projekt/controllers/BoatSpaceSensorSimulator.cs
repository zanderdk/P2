using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p2_projekt.models
{
    public class BoatSpaceSensorSimulator
    {
        

        public void ChangeStatus(BoatSpace bs, EnumBoatSpaceStatus status)
        {
            bs.BoatSpaceStatus = status;
        }
    }
}
