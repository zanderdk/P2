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
        public double Length { get; private set; }
        public double Height { get; private set; }

        public Boat Boat { get; set; } //TODO get bikonjuktiv shit working

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
