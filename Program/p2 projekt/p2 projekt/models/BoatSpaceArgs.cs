using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace p2_projekt.models
{
    public class BoatSpaceArgs : EventArgs
    {
        public readonly EnumBoatSpaceStatus Status;
        public BoatSpaceArgs(EnumBoatSpaceStatus status)
        {
            Status = status;
        }
    }
}
