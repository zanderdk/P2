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

        public int BoatId { get; set; }
        public string Name { get; set; }

        public int UserId { get; set; }
        public virtual  User User { get; set; }

        private bool _spaceChange;
        private BoatSpace _space;


        public virtual  BoatSpace BoatSpace
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

                // Opdater ny
                if (_space != null)
                {
                    _spaceChange = true;
                    _space.Boat = this;
                    _spaceChange = false;
                }
            }
        }
        public double Length { get; set; }
        public double Width { get; set; }
        public string RegistrationNumber { get; set; }


        public override string ToString()
        {
            return string.Format("{0}", Name);
        }
    }
}
