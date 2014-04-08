using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        private bool _spaceChange;
        private BoatSpace _space;
        
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
                    _spaceChange = true;
                    oldspace.Boat = null;
                    _spaceChange = false;
                }

                //opdater ny
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
