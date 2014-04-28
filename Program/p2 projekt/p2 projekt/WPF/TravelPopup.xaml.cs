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
        private Operation operation;
        private enum Operation { Add, Edit}

        public TravelPopup(ISailor u)
        {
            
            Init();

            traveller = u;
            operation = Operation.Add;
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

            traveller = s;
            Init();
            DataContext = t;
            operation = Operation.Edit;

        }


        private void AddChosenTravel(object sender, RoutedEventArgs e)
        {
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




            UserController uc = Utilities.lobopDB;
            uc.Update<User>(traveller as User);
            
            SearchController.main.selectUser(traveller as User);
            
            this.Close();
        }
    }
}
