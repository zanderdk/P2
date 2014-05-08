using p2_projekt.models;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;


namespace p2_projekt.WPF
{
    /// <summary>
    /// Interaction logic for Map.xaml
    /// </summary>
    public partial class TabMap : UserControl
    {
        public TabMap()
        {
            InitializeComponent();
            new MapControlPanel().Show();

            FillBoatSpaceRepresentations();
        }

        private void FillBoatSpaceRepresentations()
        {
            DALController us = Utilities.LobopDB;

            var boatSpaces = us.ReadAll<BoatSpace>(x => x != null).ToList();
            var wrapPanels = BoatSpacesGrid.Children.OfType<WrapPanel>().ToList();

            List<BoatSpaceRepresentation> boatspaceRepresentations = new List<BoatSpaceRepresentation>();

            for (int i = 0; i < wrapPanels.Count; i++ )
            {

                BoatSpaceRepresentation bsr = wrapPanels[i].Children.OfType<BoatSpaceRepresentation>().ElementAt(0);
                BoatSpace bs = boatSpaces[i];
                bsr.BoatSpace = bs;
                bsr.Label.Content = bs.BoatSpaceId;
            }
        }

    }
}
