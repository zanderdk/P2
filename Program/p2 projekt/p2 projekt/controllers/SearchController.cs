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
using p2_projekt.WPF;

namespace p2_projekt.controllers
{
    public static class SearchController
    {
        private static List<User> internalList;
        public static List<User> list;

        public static event Action ListToListBox;

        public static main main;

        static List<Func<User, bool>> SearchPredicates;
        public static Func<User, bool> current;

        public static Dictionary<TextBox, InfolineController> dict;

        static SearchController()
        {
            dict = new Dictionary<TextBox, InfolineController>();
            SearchPredicates = new List<Func<User, bool>>();
            list = new List<User>();
            internalList = new List<User>();         
        }
        
        private static void refresh()
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

        public static void refreshInternal()
        {
            internalList.Clear();
            UserController us = main.controller;

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

        public static void TextBox_GotFocus(object sender, RoutedEventArgs e)
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

        public static void TextBox_LostFocus(object sender, RoutedEventArgs e) //TODO fix internalRefresh
        {
            InfolineController send = dict[sender as TextBox];
            if (send.Sorted && send.predicate != null)
            {
                SearchPredicates.Add(send.predicate);
            }
            current = null;
            refreshInternal();
        }

        public static void textbox_SearchChanged(object sender, TextChangedEventArgs e)
        {
            InfolineController send = dict[(sender as TextBox)];
            if (send.Sorted)
            {
                current = SearchPredicate.getPredicat(send);
                send.predicate = current;
            }
            else
            {
                current = null;
                send.predicate = null;
            }
            refresh();
        }

    }
}
