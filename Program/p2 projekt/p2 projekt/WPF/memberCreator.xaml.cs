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
            
            if(u is Member)
            {
                password.Password = (u as Member).Password;
            }
        }

        public memberCreator()
        {
            InitializeComponent();
            operation = Operation.Add;
            Member m = new Member("", new System.Device.Location.CivicAddress());
            m.RegistrationDate = DateTime.Now;
            m.Birthday = DateTime.Now;
            currentUser = m;
            DataContext = currentUser;
            
        }

        private void save_canExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            if (name.Text == "" || birthday.Text == "" ||
               phone.Text == "" || streetName.Text == "" ||
               postalCode.Text == "" || country.Text == "" ||
               city.Text == "" || password.Password == "")
            {
                e.CanExecute = false;
            }

            if(currentUser is Member)
            {
                if ((currentUser as Member).Birthday < new DateTime(1900, 1, 1))
                    e.CanExecute = false;
            }
        }

        private void Save_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            DALController us = Utilities.LobopDB;



            if (operation == Operation.Add)
            {
                (currentUser as Member).Password = password.Password;
                us.Add(currentUser);
            }

            else if (operation == Operation.Edit)
            {
                if (currentUser is Member)
                {
                    (currentUser as Member).Password = password.Password;
                }
                us.Update(currentUser);
            }
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
