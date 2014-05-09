using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using p2_projekt.models;
using p2_projekt.WPF;
using System.ComponentModel;

namespace p2_projekt.controllers
{
    public class SearchController : INotifyPropertyChanged
    {
        private static readonly List<User> InternalList;
        public static List<User> List;

        public static event Action ListToListBox;

        public static event Func<User, bool> SearchPredicates;
        public static Func<User, bool> Current;

        public static Dictionary<TextBox, InfolineControl> Dict;
        private Dictionary<string, string> _dict;
        public string _name;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                NotifyPropertyChanged("Name");
                Current = SearchPredicate.GetPredicate("name", _name);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public SearchController()
        {
            _dict = new Dictionary<string, string>();
            //Name = "hej";
        }

        //static SearchController()
        //{
        //    Dict = new Dictionary<TextBox, InfolineControl>();
        //    List = new List<User>();
        //    InternalList = new List<User>();         
        //}

        public void AddToDict(string key, string value)
        {
            _dict[key] = value;
        }
        
        private static void Refresh()
        {
            List.Clear();
            if(Current == null)
            {
                foreach(var x in InternalList.Where(x => true))
                {
                    List.Add(x);
                }
                ListToListBox();
                return;
            }

            foreach(var x in InternalList.Where(Current))
            {
                List.Add(x);
            }
            ListToListBox();
        }

        public static void RefreshInternal()
        {
            InternalList.Clear();
            DALController us = Utilities.LobopDB;

            if(SearchPredicates == null)
            {
                foreach(var x in us.ReadAll<User>(x=> true))
                {
                    InternalList.Add(x);
                }
                Refresh();
                return;
            }

            foreach (var x in us.ReadAll<User>(x =>
                {
                    foreach(Func<User, bool> pre in SearchPredicates.GetInvocationList())
                    {
                        if (!pre(x))
                            return false;
                    }
                    return true;
                })){
                InternalList.Add(x);
            }
            Refresh();
        }

        public static void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            //InfolineControl send = Dict[(sender as TextBox)];
            //if (send.IsNotEmpty)
            //{
            //    Current = send.predicate;
            //    SearchPredicates -= send.predicate;
            //}
            //else
            //{
            //    Current = null;
            //}
            //RefreshInternal();
        }

        public static void TextBox_LostFocus(object sender, RoutedEventArgs e) //TODO fix internalRefresh
        {
            //InfolineControl send = Dict[sender as TextBox];
            //if (send.IsNotEmpty && send.predicate != null)
            //{
            //    SearchPredicates += send.predicate;
            //}
            //Current = null;
            //RefreshInternal();
        }

        public static void textbox_SearchChanged(string fieldName, string searchText)
        {
            //Current = SearchPredicate.GetPredicate(fieldName, searchText);
            //InfolineControl send = Dict[(sender as TextBox)];
            //if (send.IsNotEmpty)
            //{
            //    
            //}
            //else
            //{
            //    Current = null;
            //    send.predicate = null;
            //}
            //Refresh();
        }

    }
}
