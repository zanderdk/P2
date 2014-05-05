using p2_projekt.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace p2_projekt.controllers
{
    public class BoatController
    {
        private EnumOperation Operation;
        private Boat Boat;
        private Boat TempBoat;
        private ISailor Sailor;

        public BoatController() { }

        public BoatController(Boat boat, ISailor sailor, EnumOperation operation)
        {
            Operation = operation;
            Boat = boat;
            Sailor = sailor;
            TempBoat = new Boat()
            {
                Length = Boat.Length,
                Width = Boat.Width,
                Name = Boat.Name,
                RegistrationNumber = Boat.RegistrationNumber,
                User = Boat.User,
                UserId = Boat.UserId
            };
        }

        public void Delete(Boat b, ISailor sailor)
        {
            if (b != null)
            {
                sailor.Boats.Remove(b);
                DALController uc = Utilities.LobopDB;
                uc.Remove<Boat>(b);
            }
        }

        public void ResetChanges()
        {
            Boat.Name = TempBoat.Name;
            Boat.RegistrationNumber = TempBoat.RegistrationNumber;
            Boat.Length = TempBoat.Length;
            Boat.Width = TempBoat.Width;
        }

        public void SubmitChanges()
        {
            if (
              string.IsNullOrWhiteSpace(Boat.Name)
              )
            {
                MessageBox.Show("Udfyld alle felter");
                return;
            }
            // TODO: Check om flere værdier er valide..


            if (Operation == EnumOperation.Add)
            {
                Sailor.Boats.Add(Boat);
            }

            DALController uc = Utilities.LobopDB;
            uc.Update<User>(Sailor as User);
        }
    }
}
