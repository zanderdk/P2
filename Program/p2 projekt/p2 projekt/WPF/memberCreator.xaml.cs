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

namespace p2_projekt.WPF
{
    /// <summary>
    /// Interaction logic for memberCreator.xaml
    /// </summary>
    public partial class memberCreator : Window
    {
        User currentUser;
        private Operation operation;
        private enum Operation { Add, Edit }
        public memberCreator(User u)
        {
            InitializeComponent();
            currentUser = u;
            DataContext = currentUser;
            operation = Operation.Edit;
        }
    }
}
