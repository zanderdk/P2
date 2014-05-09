using System;
using System.Windows;
using System.Windows.Controls;
using p2_projekt.models;

namespace p2_projekt.WPF
{
    /// <summary>
    /// Interaction logic for InfolineControl.xaml
    /// </summary>
    public partial class InfolineControl : UserControl
    {
        public String Title
        {
            get { return (String)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }

        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(InfolineControl), new PropertyMetadata(""));

        public object Value {
            get { return GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public static readonly DependencyProperty ValueProperty = 
            DependencyProperty.Register("Value", typeof(object), typeof(InfolineControl), new PropertyMetadata(null));

        public String Text { get { return textbox.Text; } set { textbox.Text = value; } }

        public event TextChangedEventHandler TextChanged { add { textbox.TextChanged += value; } remove { textbox.TextChanged -= value; } }

        public event RoutedEventHandler LostFocus { add { textbox.LostFocus += value; } remove { textbox.LostFocus -= value; } }

        public event RoutedEventHandler GotFocus { add { textbox.GotFocus += value; } remove { textbox.GotFocus -= value; } }

        public Func<User, bool> predicate;

        public bool IsNotEmpty { get { return (Text != ""); } }

        public bool readOnly { set { textbox.IsReadOnly = value; } }

        public InfolineControl()
        {
            InitializeComponent();
            LayoutRoot.DataContext = this;
            if (Tag != null)
            {
                textbox.Tag = Tag;
            }
            
        }
    }
}
