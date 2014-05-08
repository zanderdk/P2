using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using p2_projekt.models;
using p2_projekt.WPF;

namespace p2_projekt.controllers
{
    public static class SearchController
    {
        private static readonly List<User> InternalList;
        public static List<User> List;

        public static event Action ListToListBox;

        public static event Func<User, bool> SearchPredicates;
        public static Func<User, bool> Current;

        public static Dictionary<TextBox, InfolineControl> Dict;

        static SearchController()
        {
            Dict = new Dictionary<TextBox, InfolineControl>();
            List = new List<User>();
            InternalList = new List<User>();         
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
            InfolineControl send = Dict[(sender as TextBox)];
            if (send.IsNotEmpty)
            {
                Current = send.predicate;
                SearchPredicates -= send.predicate;
            }
            else
            {
                Current = null;
            }
            RefreshInternal();
        }

        public static void TextBox_LostFocus(object sender, RoutedEventArgs e) //TODO fix internalRefresh
        {
            InfolineControl send = Dict[sender as TextBox];
            if (send.IsNotEmpty && send.predicate != null)
            {
                SearchPredicates += send.predicate;
            }
            Current = null;
            RefreshInternal();
        }

        public static void textbox_SearchChanged(object sender, TextChangedEventArgs e)
        {
            InfolineControl send = Dict[(sender as TextBox)];
            if (send.IsNotEmpty)
            {
                Current = SearchPredicate.GetPredicate(send.Name, send.Text);
                send.predicate = Current;
            }
            else
            {
                Current = null;
                send.predicate = null;
            }
            Refresh();
        }

    }
}
