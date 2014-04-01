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
    /// Interaction logic for main.xaml
    /// </summary>
    public partial class main : Window
    {
        Person per;
        public main(Person p)
        {
            per = p;
            InitializeComponent();
            init(p.Permissions);
        }

        void init(Permissions p)
        {
            if(p.member)
            {
                add testtab = new add(per);
                testtab.Resources.Add("readOnly", p.readOnlyMember);
                TabItem tab = new TabItem() { Header = "adder", Content = testtab };
                this.tabControler.Items.Add(tab);
            }
        }

    }
}
