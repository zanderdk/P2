using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Device.Location;
using p2_projekt.models;
using System.Collections.Generic;

namespace ModelTests
{
    [TestClass]
    public class PersonTest
    {

        Member member;
        DateTime startDate;
        DateTime endDate;

        [TestInitialize]
        public void Setup()
        {
            member = new Member("Alice", new CivicAddress());
            startDate = new DateTime(2013, 1, 1);
            endDate = new DateTime(2015, 1, 1);
        }


        [TestMethod]
        public void AddNewTravel_Travels_CountIncreasesBy1()
        {
            member.AddNewTravel(startDate, endDate);
            Assert.AreEqual(1, member.Travels.Count);
        }

        [TestMethod]
        public void AddNewTravel_Travels_CountDecreasesBy1()
        {
            member.AddNewTravel(startDate, endDate);

            member.RemoveTravel(0);
            Assert.AreEqual(0, member.Travels.Count);
        }

        [TestMethod]
        public void AddNewTravel_Travels_TravelIsAdded()
        {
            member.AddNewTravel(startDate, endDate);

            var expected = new Travel(startDate, endDate);
            var actual = member.Travels[member.Travels.Count - 1];
            Assert.IsTrue( actual.Equals(expected));
        }

        [TestMethod]
        public void RemoveTravel_Travels_TravelIsRemoved()
        {
            member.AddNewTravel(startDate, endDate);
            member.AddNewTravel(new DateTime(2014,3, 27), new DateTime(2014, 3, 31));

            var positionToRemove = 1;

            member.RemoveTravel(positionToRemove);
            var expected = new Travel(startDate, endDate);
            var actual = member.Travels[member.Travels.Count - 1];
            Assert.IsTrue(actual.Equals(expected));
        }

        [TestMethod]
        public void EditTravel_Travels_OldTravelIsReplacedWithNew()
        {
            member.AddNewTravel(startDate, endDate);

            var newStart = new DateTime(2014,7,7);
            var newEnd = new DateTime(2014, 7, 7);

            var positionToEdit = 0;

            member.EditTravel(positionToEdit, newStart, newEnd);

            var expected = new Travel(newStart, newEnd);
            var actual = member.Travels[positionToEdit];

            Assert.IsTrue(actual.Equals(expected));
        }
    }
}
