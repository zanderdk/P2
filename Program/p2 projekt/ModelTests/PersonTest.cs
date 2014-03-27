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

        

        [TestMethod]
        public void AddNewTravel()
        {
            Member member = new Member("Alice", new CivicAddress());
            var start = DateTime.Now;
            var end = new DateTime(2015, 1, 1);

            member.AddNewTravel(start, end);

            Assert.AreEqual(1, member.Travels.Count);

            var ex = new Travel(start, end);
            Assert.IsTrue( member.Travels[member.Travels.Count - 1].Equals(ex));
        }

        [TestMethod]
        public void RemoveTravel()
        {
            Member member = new Member("Alice", new CivicAddress());
            var start = DateTime.Now;
            var end = new DateTime(2015, 1, 1);

            member.AddNewTravel(start, end);
            member.AddNewTravel(new DateTime(2014,3, 27), new DateTime(2014, 3, 31));


            member.RemoveTravel(1);

            Assert.AreEqual(1, member.Travels.Count);
            var ex = new Travel(start, end);
            Assert.IsTrue(member.Travels[member.Travels.Count - 1].Equals(ex));
        }



        [TestMethod]
        public void EditTravel()
        {
            Member member = new Member("Alice", new CivicAddress());

            var start = DateTime.Now;
            var end  = new DateTime(2015, 1, 1);

            member.AddNewTravel(start, end);

            var newStart = new DateTime(2014,7,7);
            var newEnd = new DateTime(2014, 7, 7);

            var positionToEdit = 0;

            member.EditTravel(positionToEdit, newStart, newEnd);

            var newTravel = new Travel(newStart, newEnd);

            Assert.IsTrue(member.Travels[positionToEdit].Equals(newTravel));
        }
    }
}
