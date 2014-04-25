using System;
using System.Windows.Controls;
using p2_projekt.models;

namespace p2_projekt.WPF
{
    /// <summary>
    /// Interaction logic for WelcomeTab.xaml
    /// </summary>
    public partial class WelcomeTab : UserControl
    {
        public WelcomeTab(User u)
        {
            InitializeComponent();
            if (u is Member)
            {
                Panel.Children.Add(new Button { Content = "Member action" });
                Panel.Children.Add(new Button { Content = "Member action" });
                Panel.Children.Add(new Button { Content = "Member action" });
            }
            
        }
    }
}
