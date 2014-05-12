using System;
using System.Windows;
using p2_projekt.models;

namespace p2_projekt.controllers
{
    class GuestController
    {
        public Guest Guest;

        public GuestController(Guest guest)
        {
            Guest = guest;
        }

        public bool Save(Boat boat, Travel travel)
        {
            Guest.Boats.Add(boat);
            Guest.Travels.Add(travel);

            try
            {
                DALController userController = Utilities.LobopDB;
                userController.Add<User>(Guest);
                return true;
            }

            catch (InvalidOperationException)
            {
                return false;
            }
        }
    }
}
