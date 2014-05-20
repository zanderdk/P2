using System;
using System.Windows.Controls;
using p2_projekt.models;

namespace p2_projekt.WPF
{
    /// <summary>
    /// Interaction logic for Welcome.xaml
    /// </summary>
    public partial class Welcome : UserControl
    {
        public Welcome(User u)
        {
            InitializeComponent();
        }
    }
}