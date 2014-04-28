using p2_projekt.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;



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

            FillBoatSpaceRepresentations();
        }

        private void FillBoatSpaceRepresentations()
        {
            DALController us = Utilities.lobopDB;

            var boats = us.ReadAll<Boat>(x => x != null);
            var wrapPanels = BoatSpacesGrid.Children.OfType<WrapPanel>();

            List<BoatSpaceRepresentation> boatspaceRepresentations = new List<BoatSpaceRepresentation>();

            foreach (var item in wrapPanels)
            {
                BoatSpaceRepresentation bsr = item.Children.OfType<BoatSpaceRepresentation>().ElementAt(0);
                boatspaceRepresentations.Add(bsr);
            }

            for (int i = 0; i < boatspaceRepresentations.Count; i++)
            {
                BoatSpaceRepresentation bsr = boatspaceRepresentations[i];
                BoatSpace bs = boats.ElementAt(i).BoatSpace;

                bsr.BoatSpace = bs;

                bsr.Label.Content = bs.BoatId;
                // TODO brug den geniale formel til at vise rigtige plads id

            }
        }

    }
}
