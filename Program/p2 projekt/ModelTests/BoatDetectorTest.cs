using System;
using p2_projekt.models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;


namespace ModelTests
{
    [TestClass]
    public class BoatDetectorTest
    {
        [TestMethod]
        public void HasBoat()
        {
            var space = new WaterSpace(9001, 4.3, 5.4);
            Assert.AreEqual(BoatDetector.BoatStatus.Empty, BoatDetector.BoatAt(space));
            space = new WaterSpace(9002, 8.7, 3.4);
            Assert.AreEqual(BoatDetector.BoatStatus.Member, BoatDetector.BoatAt(space));
            space = new WaterSpace(9003, 10, 5);
            Assert.AreEqual(BoatDetector.BoatStatus.Guest, BoatDetector.BoatAt(space));

        }

        [TestMethod]
        public void ShouldThrowWhenNotFound()
        {
            var space = new WaterSpace(404, 4.3, 5.4);
            try
            {
                var test = BoatDetector.BoatAt(space);
            }
            catch (KeyNotFoundException _)
            {
                return;
            }
            Assert.Fail("No exception was thrown.");

        }


    }
}
