using p2_projekt.Enums;
using p2_projekt.models;

namespace p2_projekt.controllers
{
    public interface IBoatSpaceSensor
    {
        void ChangeStatus(BoatSpace bs, BoatSpaceStatus status);
    }
}
