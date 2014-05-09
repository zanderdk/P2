using System;
using System.Windows;
using System.Windows.Input;
using p2_projekt.Enums;
using p2_projekt.models;
using p2_projekt.controllers;

namespace p2_projekt.WPF
{
    /// <summary>
    /// Interaction logic for MemberPopup.xaml
    /// </summary>
    public partial class MemberPopup : Window
    {
        private readonly MemberController _controller;
        // edit
        public MemberPopup(User u)
        {
            InitializeComponent();
            DataContext = u;
            _controller = new MemberController(u, Operation.Edit);
            
            if(u is Member)
            {
                password.Password = (u as Member).Password;
            }
        }

        // add
        public MemberPopup()
        {
            InitializeComponent();
            Member m = new Member("", new System.Device.Location.CivicAddress())
            {
                RegistrationDate = DateTime.Now,
                Birthday = DateTime.Now
            };

            DataContext = m;
            _controller = new MemberController(m, Operation.Add);
        }

        private void save_canExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = !(name.Text == "" || birthday.Text == "" ||
                             phone.Text == "" || streetName.Text == "" ||
                             postalCode.Text == "" || country.Text == "" ||
                             city.Text == "" || password.Password == "");

            // hvorfor det?
            //if(currentUser is Member)
            //{
            //    if ((currentUser as Member).Birthday < new DateTime(1900, 1, 1))
            //        e.CanExecute = false;
            //}
        }

        private void Save_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            _controller.SubmitChanges(password.Password);
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
