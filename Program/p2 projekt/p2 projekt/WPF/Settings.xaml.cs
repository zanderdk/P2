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
using System.Windows.Markup;

namespace p2_projekt.WPF
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    [ContentProperty("Children")]
    public partial class Settings : ItemsControl
    {
        UIElementCollection Col;

        bool isreadonly;

        public Boolean ReadOnly { get { return isreadonly; } 
            set { 
                isreadonly = value;
                foreach(InfolineController info in Col)
                {
                    info.readOnly = value;
                }
            }}
        public UIElementCollection Children { get { return Col; } set { Col = value; } }
        public Settings()
        {
            InitializeComponent();
            Children = stack.Children;
        }
    }
}
