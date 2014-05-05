using p2_projekt.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace p2_projekt.controllers
{
    class TravelController
    {
        private ISailor Sailor;
        private Travel Travel;
        private Travel TempTravel;
        private EnumOperation Operation;

        public TravelController(Travel travel, ISailor sailor, EnumOperation operation)
        {
            Travel = travel;
            Sailor = sailor;
            Operation = operation;

            TempTravel = new Travel() {
                Start = travel.Start,
                End = travel.End, 
                TravelId = travel.TravelId, 
                User = travel.User 
            };
        }

        public TravelController()
        {
        }

        public void Delete(Travel travel, ISailor sailor)
        {
            if (travel != null)
            {
                sailor.Travels.Remove(travel);
                DALController uc = Utilities.LobopDB;
                uc.Update<User>(sailor as User);
            }
        }

        public bool SubmitChanges()
        {
            if (Travel.Start.Subtract(DateTime.Now).Days < 0)
            {
                MessageBox.Show("Vælg nyere udrejse dato");
                return false;
            }
            if (Travel.End.Subtract(Travel.Start).Days < 0)
            {
                MessageBox.Show("Vælg nyere hjemkomst dato");
                return false;
            }

            //if (!LeavingDate.SelectedDate.HasValue || !ArrivalDate.SelectedDate.HasValue)
            //{
            //    MessageBox.Show("Alle felter skal udfyldes");
            //    return;
            //}

            //if (LeavingDate.SelectedDate.Value.Subtract(DateTime.Now).Days < 0)
            //{
            //    MessageBox.Show("Vælg nyere Udrejse dato");
            //    return;
            //}
            //else if (ArrivalDate.SelectedDate.Value.Subtract(LeavingDate.SelectedDate.Value).Days < 0)
            //{
            //    MessageBox.Show("Vælg ny Hjemkost dato");
            //    return;
            //}

            if (Operation == EnumOperation.Add)
            {
                Sailor.Travels.Add(Travel);
            }


            DALController uc = Utilities.LobopDB;
            uc.Update<User>(Sailor as User);
            return true;
        }

        public void ResetChanges()
        {
            Travel.Start = TempTravel.Start;
            Travel.End = TempTravel.End;
            Travel.TravelId = TempTravel.TravelId;
            Travel.User = TempTravel.User;
        }
    }
}
