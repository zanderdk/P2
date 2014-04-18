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
    public partial class SearchTab : UserControl
    {

        private List<User> internalList;
        private List<User> list;

        main main;

        List<Func<User, bool>> SearchPredicates;
        Func<User, bool> current;

        Dictionary<TextBox, InfolineController> dict;

        void addToDict(InfolineController c)
        {
            dict.Add(c.textbox, c);
        }

        public SearchTab(main ma)
        {
            InitializeComponent();
            dict = new Dictionary<TextBox, InfolineController>();
            SearchPredicates = new List<Func<User, bool>>();
            list = new List<User>();
            internalList = new List<User>();
            main = ma;

            Add_ControllerDelegates(name);
            Add_ControllerDelegates(birthday);
            Add_ControllerDelegates(phone);
            Add_ControllerDelegates(email);
            Add_ControllerDelegates(adresse);
            Add_ControllerDelegates(postal);
            Add_ControllerDelegates(country);
            Add_ControllerDelegates(memberID);
            Add_ControllerDelegates(memberSince);
            Add_ControllerDelegates(isActive);
            Add_ControllerDelegates(boatOwner);
            Add_ControllerDelegates(boatName);
            Add_ControllerDelegates(boatID);
            Add_ControllerDelegates(boatSpace);
            Add_ControllerDelegates(boatLength);
            Add_ControllerDelegates(boatWidth);            
        }

        void Add_ControllerDelegates(InfolineController c)
        {
            c.TextChanged += textbox_SearchChanged;
            c.GotFocus += TextBox_GotFocus;
            c.LostFocus += TextBox_LostFocus;
            addToDict(c);
        }

        void ListToListBox()
        {
            listResult.Items.Clear();
            foreach(var x in list)
            {
                listResult.Items.Add(x);
            }
        }
        
        private void refresh()
        {
            list.Clear();
            if(current == null)
            {
                foreach(var x in internalList.Where(x => true))
                {
                    list.Add(x);
                }
                ListToListBox();
                return;
            }

            foreach(var x in internalList.Where(current))
            {
                list.Add(x);
            }
            ListToListBox();
            return;
        }

        public void refreshInternal()
        {
            internalList.Clear();
            UserController us = new UserController(new Utilities.Database());

            if(SearchPredicates.Count == 0)
            {
                foreach(var x in us.ReadAll<User>(x=> true))
                {
                    internalList.Add(x);
                }
                refresh();
                return;
            }

            foreach (var x in us.ReadAll<User>(x =>
                {
                    foreach(var pre in SearchPredicates)
                    {
                        if (!pre(x))
                            return false;
                    }
                    return true;
                })){
                internalList.Add(x);
            }
            refresh();
        }


        public void listResult_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListResultBoats.Items.Clear();
            User user = (User)(sender as ListBox).SelectedItem;
            if(user != null)
            {
                if(user is ISailor)
                {
                    foreach(Boat b in (user as ISailor).Boats)
                    {
                        ListResultBoats.Items.Add(b);
                    }
                }
            }
        }

        private void listResult_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            User user = (User)(sender as ListBox).SelectedItem;
            if(user != null)
            {
                main.selectUser(user);
            }
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            InfolineController send = dict[(sender as TextBox)];
            if (send.Sorted)
            {
                current = send.predicate;
                SearchPredicates.Remove(send.predicate);
            }
            else
            {
                current = null;
            }
            refreshInternal();
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e) //TODO fix internalRefresh
        {
            InfolineController send = dict[sender as TextBox];
            if (send.Sorted)
            {
                SearchPredicates.Add(send.predicate);
            }
            current = null;
            refreshInternal();
        }

        private void textbox_SearchChanged(object sender, TextChangedEventArgs e)
        {
            InfolineController send = dict[(sender as TextBox)];
            if (send.Sorted)
            {
                current = getPredicat(send);
                send.predicate = current;
            }
            else
            {
                current = null;
                send.predicate = null;
            }
            refresh();
        }


        Func<User, bool> getPredicat(InfolineController info)
        {
            if (info.Name == "name")
            {
                return x =>
                {
                    if (x.Name.ToLower().Contains(info.Text.ToLower()))
                    {
                        return true;
                    }
                    return false;
                };
            }

            if (info.Name == "phone") //TODO only numbers execption
            {
                return x =>
                    {
                        if(x.Phone == null)
                        {
                            return false;
                        }

                        if (x.Phone.Contains(info.Text))
                        {
                            return true;
                        }
                        return false;
                    };
            }

            if (info.Name == "birthday") //TODO evt gør det mulight at søge på fx. kun årstallet
            {
                DateTime test;                
                return x =>
                {

                    if (info.Text == "dag/måned/år")
                        return true;

                    if (!DateTime.TryParse(info.Text, out test))
                        return false;

                    if (!(x is IFullPersonalInfo))
                        return false;

                    if((x as IFullPersonalInfo).Birthday == test)
                    {
                        return true;
                    }

                    return false;
                };
            }

            if (info.Name == "email") //TODO only numbers execption
            {
                return x =>
                {
                    if (!(x is IFullPersonalInfo))
                        return false;
                    
                    if((x as IFullPersonalInfo).Email == null)
                    {
                        return false;
                    }

                    if((x as IFullPersonalInfo).Email.ToLower().Contains(info.Text))
                    {
                        return true;
                    }

                    return false;
                };
            }

            if (info.Name == "adresse")
            {
                    return x =>
                    {
                        if (!(x is IBasicPersonalInfo))
                            return false;

                        if ((x as IBasicPersonalInfo).Adress.AddressLine1 == null)
                        {
                            return false;
                        }

                        if ((x as IBasicPersonalInfo).Adress.AddressLine1.ToLower().Contains(info.Text))
                        {
                            return true;
                        }

                        return false;
                    };
            }

            if (info.Name == "postal")
            {
                return x =>
                {
                    if (!(x is IBasicPersonalInfo))
                        return false;

                    if ((x as IBasicPersonalInfo).Adress.PostalCode == null)
                    {
                        return false;
                    }

                    if ((x as IBasicPersonalInfo).Adress.PostalCode.ToString().ToLower().Contains(info.Text))
                    {
                        return true;
                    }

                    return false;
                };
            }

            if (info.Name == "country")
            {
                return x =>
                {
                    if (!(x is IBasicPersonalInfo))
                        return false;

                    if ((x as IBasicPersonalInfo).Adress.CountryRegion == null)
                    {
                        return false;
                    }

                    if ((x as IBasicPersonalInfo).Adress.CountryRegion.ToString().ToLower().Contains(info.Text))
                    {
                        return true;
                    }

                    return false;
                };
            }

            if (info.Name == "memberID")
            {
                return x =>
                {
                    if (!(x is Member))
                        return false;

                    if ((x as Member).MembershipNumber.ToString().Contains(info.Text))
                    {
                        return true;
                    }
                    return false;
                };
            }

            if (info.Name == "memberSince") //TODO evt gør det mulight at søge på fx. kun årstallet
            {
                DateTime test;
                return x =>
                {

                    if (info.Text == "dag/måned/år")
                        return true;

                    if (!DateTime.TryParse(info.Text, out test))
                        return false;

                    if (!(x is IFullPersonalInfo))
                        return false;

                    var reg = (x as IFullPersonalInfo).RegistrationDate;

                    if (reg.Date == test.Date)
                    {
                        return true;
                    }

                    return false;
                };
            }

            if (info.Name == "isActive")
            {
                return x =>
                {
                    if (!(x is Member))
                        return false;

                    bool test = info.Text.ToLower() == "ja" ? true : false;

                    if ((x as Member).IsActive == test)
                    {
                        return true;
                    }

                    return false;
                };
            }

            if (info.Name == "boatOwner")
            {
                return x => {

                    if (!(x is ISailor))
                        return false;

                    foreach(Boat b in (x as ISailor).Boats)
                    {
                        if (b.User.Name.ToLower().Contains(info.Text.ToLower()))
                            return true;
                    }

                    return false;

                };
            }

            if (info.Name == "boatName")
            {
                return x => {

                    if (!(x is ISailor))
                        return false;

                    foreach (Boat b in (x as ISailor).Boats)
                    {
                        if (b.Name.ToLower().Contains(info.Text.ToLower()))
                            return true;
                    }

                    return false;
                    
                };
            }

            if (info.Name == "boatID")
            {
                return x =>
                {
                    int id;

                    if(!int.TryParse(info.Text, out id))
                        return false;

                    if (!(x is ISailor))
                        return false;

                    foreach (Boat b in (x as ISailor).Boats)
                    {
                        if (b.BoatId == id)
                            return true;
                    }

                    return false;

                };
            }

            if (info.Name == "boatName")
            {
                return x =>
                {

                    if (!(x is ISailor))
                        return false;

                    foreach (Boat b in (x as ISailor).Boats)
                    {
                        if (b.BoatSpace != null)
                        {
                            if (b.BoatSpace.info.ToLower().Contains(info.Text.ToLower()))
                                return true;
                        }
                            
                    }

                    return false;

                };
            }

            if (info.Name == "boatLength")
            {
                return x =>
                {
                    int id;

                    if (!int.TryParse(info.Text, out id))
                        return false;

                    if (!(x is ISailor))
                        return false;

                    foreach (Boat b in (x as ISailor).Boats)
                    {
                        if (b.Length == id)
                            return true;
                    }

                    return false;

                };
            }

            if (info.Name == "boatWidth")
            {
                return x =>
                {
                    int id;

                    if (!int.TryParse(info.Text, out id))
                        return false;

                    if (!(x is ISailor))
                        return false;

                    foreach (Boat b in (x as ISailor).Boats)
                    {
                        if (b.Width == id)
                            return true;
                    }

                    return false;

                };
            }

            throw new InvalidOperationException();
        }

    }
}
