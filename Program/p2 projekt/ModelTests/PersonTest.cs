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
            Member member = new Member("Simon", new CivicAddress());
            
            member.AddNewTravel(DateTime.Now, new DateTime(2015, 1, 1));

            Assert.AreEqual(1, member.Travels.Count);
            //Assert.AreEqual(, member.Travels[member.Travels.Count - 1]);

        }

        [TestMethod]
        public void EditTravel()
        {
            Member member = new Member("Simon", new CivicAddress());

            member.AddNewTravel(DateTime.Now, new DateTime(2015, 1, 1));

            Assert.AreEqual(member.Travels.Count, 1);

        }
    }
}
