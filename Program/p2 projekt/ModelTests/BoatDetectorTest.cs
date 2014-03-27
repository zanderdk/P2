using System;
using p2_projekt.models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ModelTests
{
    [TestClass]
    public class BoatDetectorTest
    {
        [TestMethod]
        public void HasBoat()
        {
            var space = new WaterSpace(901, 4.3, 5.4);
            Assert.AreEqual(BoatDetector.BoatStatus.Empty, BoatDetector.BoatAt(space));
            space = new WaterSpace(902, 8.7, 3.4);
            Assert.AreEqual(BoatDetector.BoatStatus.Guest, BoatDetector.BoatAt(space));
            space = new WaterSpace(903, 10, 5);
            Assert.AreEqual(BoatDetector.BoatStatus.Member, BoatDetector.BoatAt(space));
        }
    }
}
