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
using p2_projekt.Enums;
using p2_projekt.models;
using p2_projekt.controllers;

namespace p2_projekt.WPF
{
    /// <summary>
    /// Interaction logic for TravelAddPopup.xaml
    /// </summary>
    public partial class TravelPopup : Window
    {
        private ISailor Sailor;
        private Travel Travel;
        private Travel tempTravel;

        private TravelController controller;

        public TravelPopup(ISailor sailor)
        {
            Init();
            Sailor = sailor;
            Travel = new Travel(DateTime.Now, DateTime.Now);
            controller = new TravelController(Travel, sailor, Operation.Add);
            Title = "Tilføj rejse";
            DataContext = Travel;
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
            Travel = t;
            Sailor = s;
            Init();
            DataContext = t;
            Title = "Redigér rejse";
            controller = new TravelController(Travel, Sailor, Operation.Edit);
        }


        private void Submit(object sender, RoutedEventArgs e)
        {
            if (controller.SubmitChanges())
            {
                this.Close();
            }
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            controller.ResetChanges();
            this.Close();
        }
    }
}
