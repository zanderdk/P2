using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace p2_projekt.models
{
    public static class BoatDetector
    {
        public enum BoatStatus {Empty, Member, Guest};
        public static BoatStatus BoatAt(WaterSpace space)
        {
            // Vær ommærksom på at dette måske ikke er den bedste måde at gør det på
            foreach (SettingsProperty currentProperty in HarborStatus.Default.Properties)
            {
                if (String.Compare(currentProperty.Name, "space" + space.BoatSpaceId) == 0)
                    return (BoatStatus) Convert.ToInt32( currentProperty.DefaultValue);
            }
            
            throw new KeyNotFoundException("Space was not found");
        }
    }
}
