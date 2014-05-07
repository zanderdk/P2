using p2_projekt.Enums;
using p2_projekt.models;

namespace p2_projekt.controllers
{
    public class BoatSpaceSensorSimulator
    {
        

        public void ChangeStatus(BoatSpace bs, BoatSpaceStatus status)
        {
            bs.BoatSpaceStatus = status;
        }
    }
}
