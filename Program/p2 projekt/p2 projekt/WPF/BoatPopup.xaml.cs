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
    /// Interaction logic for NewBoatPopup.xaml
    /// </summary>
    public partial class BoatPopup : Window
    {
        private Boat Boat;
        private ISailor Sailor;

        public BoatPopup(ISailor s)
        {

            Init();
            Sailor = s;
            Boat = new Boat();
            Boat.User = Sailor as User;
            DataContext = Boat;
        }

        public BoatPopup(Boat b, ISailor s)
        {
            Init();
        }

        private void Init()
        {
            InitializeComponent();
        }

        private void Submit(object sender, RoutedEventArgs e)
        {

            Sailor.Boats.Add(Boat);

            DALController uc = Utilities.LobopDB;
            uc.Update<User>(Sailor as User);

            this.Close();
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
