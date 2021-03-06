﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using p2_projekt.controllers;
using p2_projekt;
using p2_projekt.models;
using System.Device.Location;
using System.Collections.Generic;
using System.Linq;

namespace ModelTests
{
    [TestClass]
    public class SearchControllerTest
    {
        SearchController controller;
        DALController dalcontroller;
        Member alice;
        Member bob;

        [TestInitialize]
        public void Setup()
        {
            controller = new SearchController();
            dalcontroller = Utilities.LobopDB;

            alice = new Member("alice", new CivicAddress());
            alice.Birthday = new DateTime(2013, 1, 1);
            alice.RegistrationDate = new DateTime(2013, 1, 1);
            alice.Phone = "1234";

            Boat b1 = new Boat("asd", 20, 20);
            alice.Boats.Add(b1);

            dalcontroller.Add<User>(alice);

            bob = new Member("bob", new CivicAddress());
            bob.Birthday = new DateTime(2015, 1, 1);
            bob.RegistrationDate = new DateTime(2015, 1, 1);
            bob.Phone = "4321";
            Boat b2 = new Boat("asd123asd", 20, 20);
            bob.Boats.Add(b2);

            dalcontroller.Add<User>(bob);
        }

        [TestCleanup]
        public void Teardown()
        {
            dalcontroller.Remove<User>(bob);
            dalcontroller.Remove<User>(alice);
        }

        [TestMethod]
        public void NoSearchSpecified_ReturnsAllUsers()
        {
            Action<IEnumerable<User>> action = delegate(IEnumerable<User> y)
            {
                IEnumerable<User> databaseAll = dalcontroller.ReadAll<User>(x => true);

                Assert.IsTrue(listEquals(y,databaseAll));
            };

            simulateSearch(action, "name", "");
        }

        private bool listEquals(IEnumerable<User> a, IEnumerable<User> b){
            return a.Count() == b.Count()
                    && a.Select(x => x.UserId).Except(b.Select(x => x.UserId)).Count() == 0;
        }

        [TestMethod]
        public void SearchBoatId_ValidInputUserFound()
        {
            Action<IEnumerable<User>> action = delegate(IEnumerable<User> y)
            {
                Assert.IsTrue(y.Count() == 1 && y.Contains<User>(alice));
            };

            simulateSearch(action, "boatID", alice.Boats[0].BoatId.ToString());
        }

        [TestMethod]
        public void SearchBirthday_ValidInputUserFound()
        {
            Action<IEnumerable<User>> action = delegate(IEnumerable<User> y)
            {
                Assert.IsTrue(y.Count() == 1 && y.Contains<User>(alice));
            };

            simulateSearch(action, "birthday", "1/1/2013");
        }

        [TestMethod]
        public void SearchBoatID_InvalidInput_UserNotFound()
        {
            Action<IEnumerable<User>> action = delegate(IEnumerable<User> y)
            {
                Assert.IsTrue(y.Count() == 0);
            };

            simulateSearch(action, "boatID", "123123123");
        }

        [TestMethod]
        public void SearchBirthday_InvalidInput()
        {
            Action<IEnumerable<User>> action = delegate(IEnumerable<User> y)
            {
                Assert.IsTrue(y.Count() == 0);
            };

            simulateSearch(action, "birthday", "#$t1/1/2013");
        }

        [TestMethod]
        public void SearchControllerTest_UserFoundByName()
        {
            Action<IEnumerable<User>> action = delegate(IEnumerable<User> y)
            {
                Assert.IsTrue(y.Count() == 1 && y.Contains<User>(alice));
            };

            simulateSearch(action, "name", "ali");
        }

        private void simulateSearch(Action<IEnumerable<User>> listUpdated, string searchField, string searchText){
            controller.ListUpdated += delegate { };

            // simulate user action
            controller.TextBox_GotFocus(searchField, "");

            controller.ListUpdated += listUpdated;
            controller.textbox_SearchChanged(searchField, searchText);
            
            controller.TextBox_LostFocus(searchField, searchText);


            controller.ListUpdated -= listUpdated;
        }


        [TestMethod]
        public void SearchMultipleParams_FoundUser()
        {
            Action<IEnumerable<User>> action = delegate(IEnumerable<User> y)
            {
                Assert.IsTrue(y.Count() == 1 && y.Contains<User>(alice));
            };

            string searchField1 = "phone";
            string searchText1 = "1234";

            controller.ListUpdated += delegate { };
            // simulate user action
            controller.TextBox_GotFocus(searchField1, "");
            controller.textbox_SearchChanged(searchField1, searchText1);
            controller.TextBox_LostFocus(searchField1, searchText1);

            simulateSearch(action, "name", "ali");
        }

        [TestMethod]
        public void SearchMultipleParams_NotFoundUser()
        {
            Action<IEnumerable<User>> action = delegate(IEnumerable<User> y)
            {
                Assert.IsTrue(y.Count() == 0);
            };

            string searchField1 = "phone";
            string searchText1 = "123124";

            controller.ListUpdated += delegate { };
            // simulate user action
            controller.TextBox_GotFocus(searchField1, "");
            controller.textbox_SearchChanged(searchField1, searchText1);
            controller.TextBox_LostFocus(searchField1, searchText1);

            simulateSearch(action, "name", "ali");
        }

        

        [TestMethod]
        public void UserNotFoundByName()
        {
            Action<IEnumerable<User>> action = delegate(IEnumerable<User> y)
            {
                Assert.IsTrue(y.Count() == 0);
            };

            simulateSearch(action, "name", "akjsndjka");
        }
    }
}
