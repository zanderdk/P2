using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using p2_projekt.WPF;
using p2_projekt.models;

namespace p2_projekt.controllers
{
    class MapController
    {
        public void FillBoatSpaceRepresentations(List<BoatSpaceRepresentation> boatSpaceRepresentations)
        {
            DALController us = Utilities.LobopDB;

            var boatSpaces = us.ReadAll<BoatSpace>(x => x != null).ToList();


            for (int i = 0; i < boatSpaces.Count; i++)
            {
                BoatSpace bs = boatSpaces[i];
                BoatSpaceRepresentation bsr = boatSpaceRepresentations[i];
                bsr.BoatSpace = bs;
                bsr.Label.Content = bs.BoatSpaceId;
            }
        }
    }
}
