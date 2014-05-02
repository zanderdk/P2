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
        private Boat TempBoat;
        private ISailor Sailor;
        private Operation operation;
        private enum Operation { Add, Edit }

        public BoatPopup(ISailor s)
        {

            Init();
            Sailor = s;
            Boat = new Boat();
            Boat.User = Sailor as User;
            DataContext = Boat;
            operation = Operation.Add;
        }

        public BoatPopup(Boat b, ISailor s)
        {
            Boat = b;
            Sailor = s;
            TempBoat = new Boat()
            {
                BoatSpace = b.BoatSpace,
                Length = b.Length,
                Width = b.Width,
                Name = b.Name,
                RegistrationNumber = b.RegistrationNumber,
                User = b.User,
                UserId = b.UserId
            };
            Init();

            DataContext = b;
            operation = Operation.Edit;
        }

        private void Init()
        {
            InitializeComponent();
        }

        private void Submit(object sender, RoutedEventArgs e)
        {
            if(
                !string.IsNullOrWhiteSpace(Boat.Name))
            {
                MessageBox.Show("Udfyld alle felter");
                return;
            }
            // TODO: Check om flere værdier er valide..


            if (operation == Operation.Add)
            {
                Sailor.Boats.Add(Boat);
            }

            

            DALController uc = Utilities.LobopDB;
            uc.Update<User>(Sailor as User);

            this.Close();
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            Boat.Name = TempBoat.Name;
            Boat.RegistrationNumber = TempBoat.RegistrationNumber;
            Boat.Length = TempBoat.Length;
            Boat.Width = TempBoat.Width;
            this.Close();
        }
    }
}
