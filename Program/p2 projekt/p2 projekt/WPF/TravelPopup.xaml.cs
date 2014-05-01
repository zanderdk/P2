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
using p2_projekt.models;
using p2_projekt.controllers;

namespace p2_projekt.WPF
{
    /// <summary>
    /// Interaction logic for TravelAddPopup.xaml
    /// </summary>
    public partial class TravelPopup : Window
    {
        private ISailor traveller;
        private Travel travel;
        private Travel tempTravel;
        private Operation operation;
        private enum Operation { Add, Edit}

        public TravelPopup(ISailor u)
        {
            
            Init();

            traveller = u;
            operation = Operation.Add;
            Title = "Tilføj rejse";
        }

        private void Init(){
            InitializeComponent();
        }

        /// <summary>
        /// Edit travel constructor
        /// </summary>
        /// <param name="t"></param>
        public TravelPopup(Travel t, ISailor s)
        {
            travel = t;
            tempTravel = new Travel() { Start = t.Start, End = t.End, TravelId = t.TravelId, User = t.User };
            traveller = s;
            Init();
            DataContext = t;
            operation = Operation.Edit;
            Title = "Redigér rejse";
        }


        private void Submit(object sender, RoutedEventArgs e)
        {
            if (!LeavingDate.SelectedDate.HasValue || !ArrivalDate.SelectedDate.HasValue)
            {
                MessageBox.Show("Alle felter skal udfyldes");
                return;
            }

            if (LeavingDate.SelectedDate.Value.Subtract(DateTime.Now).Days < 0)
            {
                MessageBox.Show("Vælg nyere Udrejse dato");
                return;
            }
            else if(ArrivalDate.SelectedDate.Value.Subtract(LeavingDate.SelectedDate.Value).Days < 0)
            {
                MessageBox.Show("Vælg ny Hjemkost dato");
                return;
            }
            
            if (operation == Operation.Add)
            {
                Travel TravelToBeAdded = new Travel() { Start = LeavingDate.SelectedDate.Value, End = ArrivalDate.SelectedDate.Value, User = traveller };
                (traveller as ISailor).Travels.Add(TravelToBeAdded);
            }


            DALController uc = Utilities.LobopDB;
            uc.Update<User>(traveller as User);
            
            
            MainController.selectUser(traveller as User);
            
            this.Close();
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            travel = tempTravel;
            MainController.selectUser(traveller as User);
            this.Close();
        }
    }
}
