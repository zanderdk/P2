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
    public class SearchController
    {
        private readonly List<User> _internalList;
        private List<User> _list;

        public event Action<IEnumerable<User>> ListUpdated;

        private event Func<User, bool> _searchPredicates;
        private Func<User, bool> _current;

        private Dictionary<string, Func<User, bool>> _dict;

        public SearchController()
        {
            _dict = new Dictionary<string, Func<User, bool>>();
            _list = new List<User>();
            _internalList = new List<User>();
        }

        public void AddToDict(string key, Func<User, bool> value)
        {
            _dict[key] = value;
        }
        
        private void RefreshResults()
        {
            _list.Clear();
            
            if(_current == null)
            {
                _list.AddRange(_internalList);
                ListUpdated(_list);
            }
            else
            {
                _list.AddRange(_internalList.Where(_current));

                foreach (var x in _internalList.Where(_current))
                {
                    _list.Add(x);
                }
                ListUpdated(_list);
            }

            
        }

        private void RefreshInternal()
        {
            _internalList.Clear();
            DALController us = Utilities.LobopDB;

            if(_searchPredicates == null)
            {
                foreach(var x in us.ReadAll<User>(x=> true))
                {
                    _internalList.Add(x);
                }
                RefreshResults();
                return;
            }

            foreach (var x in us.ReadAll<User>(x =>
                {
                    foreach(Func<User, bool> pre in _searchPredicates.GetInvocationList())
                    {
                        if (!pre(x))
                            return false;
                    }
                    return true;
                })){
                _internalList.Add(x);
            }
            RefreshResults();
        }

        public void TextBox_GotFocus(string fieldName, string searchText)
        {
            if (!string.IsNullOrEmpty(searchText))
            {
                _current = _dict[fieldName];
                _searchPredicates -= _dict[fieldName];
            }
            else
            {
                _current = null;
            }
            RefreshInternal();
        }

        public void TextBox_LostFocus(string fieldName, string searchText) //TODO fix internalRefresh
        {
            if (!string.IsNullOrEmpty(searchText))
            {
                _searchPredicates += _dict[fieldName];
            }
            _current = null;
            RefreshInternal();
        }

        public void textbox_SearchChanged(string fieldName, string searchText)
        {
            if (string.IsNullOrEmpty(searchText))
            {
                _current = null;
            }
            else
            {
                _current = SearchPredicate.GetPredicate(fieldName, searchText);
                AddToDict(fieldName, _current);
            }
            RefreshResults();
        }
    }
}
