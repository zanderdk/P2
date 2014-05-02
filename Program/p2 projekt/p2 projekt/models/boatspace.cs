using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace p2_projekt.models
{
    public abstract class BoatSpace
    {
        public BoatSpace() { } // må kun bruges af Entity.

        [Key,ForeignKey("Boat")]
        public int BoatId { get; set; }
        public String Info { get; set; }
        public double Length { get; private set; }
        public double Width { get; private set; }

        public event EventHandler<BoatSpaceArgs> OnBoatSpaceChange = delegate { };

        private EnumBoatSpaceStatus boatSpaceStatus;
        public EnumBoatSpaceStatus BoatSpaceStatus 
        { 
            get
            {
                return boatSpaceStatus;
            }
            set
            {
                boatSpaceStatus = value;
                OnBoatSpaceChange(this, new BoatSpaceArgs(value));
                
            }
        }

        private bool _boatChange;
        private Boat _boat;
        public virtual Boat Boat 
        { 
            get
            {
                return _boat;
            }
            set
            {
                if (_boatChange) return;

                if (_boat == null)
                {
                    _boatChange = true;
                    _boat = value;
                    _boatChange = false;
                }
                else
                {
                    if (value == null)
                    {
                        _boatChange = true;
                        _boat.BoatSpace = null;
                        _boat = null;
                        _boatChange = false;
                    }
                    else
                    {
                        if(_boat != value) //entity gør dette men det er ikke et problem da (_boat altid er == value).
                        {
                            throw new Exception("This spot already has a boat on it");
                        }               
                    }
                }
            }
        }

        public BoatSpace(double length, double height)
        {
            Length = length;
            Width = height;
        }

        public override string ToString()
        {
            return String.Format("Info: {0}, Tilhørende båd: {1}", Info, Boat);
        }
    }
}
