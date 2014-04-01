using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using p2_projekt.models;

namespace ModelTests
{
    [TestClass]
    public class TravelTest
    {

        DateTime start;
        DateTime end;
        Travel t1;
        Travel t2;

        [TestInitialize]
        public void Setup()
        {
            start = new DateTime(1, 1, 1);
            end = new DateTime(2, 2, 2);
            t1 = new Travel(start, end);
            t2 = new Travel(start, end);
        }

        [TestMethod]
        public void Equal_NoStateChanged_IsEqual()
        {
            Assert.IsTrue(t1.Equals(t2));
        }

        [TestMethod]
        public void GetHashCode_NoStateChanged_SameHash()
        {
            Assert.IsTrue(t1.GetHashCode() == t2.GetHashCode());
        }
    }
}
