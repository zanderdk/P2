using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p2_projekt.models
{
    public abstract class BoatSpace
    {

        public int Id { get; private set; }
        public String info { get; set; }
        public double Length { get; private set; }
        public double Height { get; private set; }

        private bool _boatChange;
        private Boat _boat;
        public Boat Boat 
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
                    _boat.Space = this;
                    _boatChange = false;
                }
                else
                {
                    if (value == null)
                    {
                        _boatChange = true;
                        _boat.Space = null;
                        _boat = null;
                        _boatChange = false;
                    }
                    else
                    {
                        throw new Exception("This spot already has a boat on it");
                    }
                }

            }
        }

        public BoatSpace(int id, double length, double height)
        {
            Id = id;
            Length = length;
            Height = height;
        }
    }

    public class WaterSpace : BoatSpace
    {
        public WaterSpace(int id, double length, double height) : base(id, length, height) {}
    }

    public class LandSpace : BoatSpace
    {
        public LandSpace() : base(0, 0, 0) { } //TODO
    }
}
