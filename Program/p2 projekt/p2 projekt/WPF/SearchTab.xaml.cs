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

namespace p2_projekt.WPF
{
    /// <summary>
    /// Interaction logic for SearchTab.xaml
    /// </summary>
    public partial class SearchTab : UserControl
    {
        public SearchTab()
        {
            InitializeComponent();

            Add_ControllerDelegates(name);
            Add_ControllerDelegates(birthday);
            Add_ControllerDelegates(phone);
            Add_ControllerDelegates(email);
            Add_ControllerDelegates(adresse);
            Add_ControllerDelegates(postal);
            Add_ControllerDelegates(country);
            Add_ControllerDelegates(memberID);
            Add_ControllerDelegates(memberSince);
            Add_ControllerDelegates(memberTimeTotal);
            Add_ControllerDelegates(isActive);
            Add_ControllerDelegates(boatOwner);
            Add_ControllerDelegates(boatName);
            Add_ControllerDelegates(boatID);
            Add_ControllerDelegates(boatSpace);
            Add_ControllerDelegates(boatLength);
            Add_ControllerDelegates(boatWidth);
            
        }

        public void Add_ControllerDelegates(InfolineController i)
        {
            i.TextChanged += delegate { textbox_SearchChanged(); };
        }

        public void textbox_SearchChanged()
        {
            
        }


        public void listResult_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void listResult_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
