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
using System.Windows.Shapes;

namespace p2_projekt.WPF
{
    /// <summary>
    /// Interaction logic for MapControlPanel.xaml
    /// </summary>
    public partial class MapControlPanel : Window
    {
        public MapControlPanel()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EnumBoatSpaceStatus status = EnumBoatSpaceStatus.Empty;
            switch (statusDropdown.SelectedIndex)
            {
                case 0:
                    status = EnumBoatSpaceStatus.GuestBoat;
                    break;
                case 1:
                    status = EnumBoatSpaceStatus.Empty;
                    break;
                case 2:
                    status = EnumBoatSpaceStatus.MemberBoat;
                    break;
                default:
                    MessageBox.Show("Ikke gyldig status");
                    return;
            }
            int id = int.Parse(boatSpaceId.Text);
            BoatSpace boatSpace = Utilities.LobopDB.Read<BoatSpace>(x => x.BoatSpaceId == id);
            if (boatSpace == null)
            {
                MessageBox.Show("bådplads ikke fundet");
            }
            else
            {
                new BoatSpaceSensorSimulator().ChangeStatus(boatSpace, status);
            }
        }
    }
}
