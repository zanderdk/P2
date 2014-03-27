using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using p2_projekt.models;

namespace ModelTests
{
    [TestClass]
    public class TravelTest
    {
        [TestMethod]
        public void Equal()
        {
            DateTime start = new DateTime(1,1,1);
            DateTime end = new DateTime(2,2,2);
            Travel t1 = new Travel(start, end);
            Travel t2 = new Travel(start, end);

            Assert.IsTrue(t1.Equals(t2));
        }
    }
}
