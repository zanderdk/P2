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
using System.Windows.Navigation;
using System.Windows.Shapes;
using p2_projekt.models;

namespace p2_projekt.WPF
{
    /// <summary>
    /// Interaction logic for InfolineController.xaml
    /// </summary>
    public partial class InfolineController : UserControl
    {
        public String Title
        {
            get { return (String)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }

        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(InfolineController), new PropertyMetadata(""));

        public object Value {
            get { return GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public static readonly DependencyProperty ValueProperty = 
            DependencyProperty.Register("Value", typeof(object), typeof(InfolineController), new PropertyMetadata(null));

        public String Text { get { return textbox.Text; } set { textbox.Text = value; } }

        public event TextChangedEventHandler TextChanged { add { textbox.TextChanged += value; } remove { textbox.TextChanged -= value; } }

        public event RoutedEventHandler LostFocus { add { textbox.LostFocus += value; } remove { textbox.LostFocus -= value; } }

        public event RoutedEventHandler GotFocus { add { textbox.GotFocus += value; } remove { textbox.GotFocus -= value; } }

        public Func<User, bool> predicate;

        public bool IsNotEmpty { get { return (Text != ""); } }

        public bool readOnly { set { textbox.IsReadOnly = value; } }

        public InfolineController()
        {
            InitializeComponent();
            LayoutRoot.DataContext = this;
        }
    }
}
