using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p2_projekt.models
{
    public class Boat
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public User Owner { get; set; }

        private bool _SpaceChange;
        private BoatSpace _Space;

        public bool IsReplacingABoat;

        public BoatSpace Space
        {
            get
            {
                return _Space;
            }

            set
            {
                BoatSpace oldspace = _Space;
                _Space = value;
                if (oldspace != null)
                {
                    IsReplacingABoat = true;
                    _SpaceChange = true;
                    _Space.Boat = null;                    
                    _SpaceChange = false;
                }
            }
        }
        public double Lenght { get; set; }
        public double Width { get; set; }
        public string registrationNumber { get; set; }
    }
}
