using System;
using p2_projekt.Enums;

namespace p2_projekt.models
{
    public class BoatSpaceArgs : EventArgs
    {
        public readonly BoatSpaceStatus Status;
        public BoatSpaceArgs(BoatSpaceStatus status)
        {
            Status = status;
        }
    }
}
