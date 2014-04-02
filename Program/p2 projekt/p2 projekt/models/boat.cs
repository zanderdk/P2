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
        public Person Owner { get; set; }

        private bool _spaceChange;
        private BoatSpace _space;

        public bool IsReplacingABoat;

        public BoatSpace Space
        {
            get
            {
                return _space;
            }

            set
            {
                if (_spaceChange) return;

                BoatSpace oldspace = _space;
                _space = value;

                // Opdater gammel
                if (oldspace != null)
                {
                    IsReplacingABoat = true;
                    _spaceChange = true;
                    _space.Boat = null;                    
                    _spaceChange = false;
                }

                //opdater nu
                if (_space != null)
                {
                    _spaceChange = true;
                    _space.Boat = this;
                    _spaceChange = false;
                }
            }
        }
        public double Lenght { get; set; }
        public double Width { get; set; }
        public string registrationNumber { get; set; }
    }
}
