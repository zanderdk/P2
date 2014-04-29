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
        private static List<User> internalList;
        public static List<User> List;

        public static event Action ListToListBox;

        public static main Main;

        static List<Func<User, bool>> SearchPredicates;
        public static Func<User, bool> Current;

        public static Dictionary<TextBox, InfolineController> Dict;

        static SearchController()
        {
            Dict = new Dictionary<TextBox, InfolineController>();
            SearchPredicates = new List<Func<User, bool>>();
            List = new List<User>();
            internalList = new List<User>();         
        }
        
        private static void Refresh()
        {
            List.Clear();
            if(Current == null)
            {
                foreach(var x in internalList.Where(x => true))
                {
                    List.Add(x);
                }
                ListToListBox();
                return;
            }

            foreach(var x in internalList.Where(Current))
            {
                List.Add(x);
            }
            ListToListBox();
        }

        public static void RefreshInternal()
        {
            internalList.Clear();
            DALController us = Main.controller;

            if(SearchPredicates.Count == 0)
            {
                foreach(var x in us.ReadAll<User>(x=> true))
                {
                    internalList.Add(x);
                }
                Refresh();
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
            Refresh();
        }

        public static void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            InfolineController send = Dict[(sender as TextBox)]; // TODO hmmm
            if (send.Sorted)
            {
                Current = send.predicate;
                SearchPredicates.Remove(send.predicate);
            }
            else
            {
                Current = null;
            }
            RefreshInternal();
        }

        public static void TextBox_LostFocus(object sender, RoutedEventArgs e) //TODO fix internalRefresh
        {
            InfolineController send = Dict[sender as TextBox];
            if (send.Sorted && send.predicate != null)
            {
                SearchPredicates.Add(send.predicate);
            }
            Current = null;
            RefreshInternal();
        }

        public static void textbox_SearchChanged(object sender, TextChangedEventArgs e)
        {
            InfolineController send = Dict[(sender as TextBox)];
            if (send.Sorted)
            {
                Current = SearchPredicate.GetPredicat(send);
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
