using p2_projekt.Enums;
using p2_projekt.models;
using System.Windows;

namespace p2_projekt.controllers
{
    public class BoatController
    {
        private readonly Operation _operation;
        private readonly Boat _boat;
        private readonly Boat _tempBoat;
        private readonly ISailor _sailor;

        public BoatController() { }

        public BoatController(Boat boat, ISailor sailor, Operation operation)
        {
            _operation = operation;
            _boat = boat;
            _sailor = sailor;
            _tempBoat = new Boat
            {
                Length = _boat.Length,
                Width = _boat.Width,
                Name = _boat.Name,
                RegistrationNumber = _boat.RegistrationNumber,
                User = _boat.User,
                UserId = _boat.UserId
            };
        }

        public static void Delete(Boat b)
        {
            if (b != null)
            {
                (b.User as ISailor).Boats.Remove(b);
                DALController uc = Utilities.LobopDB;
                uc.Remove(b);
            }
        }

        public void ResetChanges()
        {
            _boat.Name = _tempBoat.Name;
            _boat.RegistrationNumber = _tempBoat.RegistrationNumber;
            _boat.Length = _tempBoat.Length;
            _boat.Width = _tempBoat.Width;
        }

        public void SubmitChanges()
        {
            if (
              string.IsNullOrWhiteSpace(_boat.Name)
              )
            {
                MessageBox.Show("Udfyld alle felter");
                return;
            }
            // TODO: Check om flere værdier er valide..


            if (_operation == Operation.Add)
            {
                _sailor.Boats.Add(_boat);
            }

            DALController uc = Utilities.LobopDB;
            uc.Update(_sailor as User);
        }
    }
}
