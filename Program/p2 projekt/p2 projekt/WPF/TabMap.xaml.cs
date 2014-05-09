using p2_projekt.controllers;
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

            
            List<BoatSpaceRepresentation> boatSpaceRepresentations = new List<BoatSpaceRepresentation>();
            var wrapPanels = BoatSpacesGrid.Children.OfType<WrapPanel>().ToList();

            foreach (var item in wrapPanels)
            {
                BoatSpaceRepresentation bsr = item.Children.OfType<BoatSpaceRepresentation>().ElementAt(0);
                boatSpaceRepresentations.Add(bsr);
            }

            MapController _controller = new MapController();
            _controller.FillBoatSpaceRepresentations(boatSpaceRepresentations);
        }
    }
}
