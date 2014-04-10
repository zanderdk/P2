using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using p2_projekt.models;

namespace ModelTests
{
    [TestClass]
    public class BoatTest
    {
        [TestMethod]
        public void FreeBoatToFreeSpace_IsSet()
        {
            Boat BoatOne = new Boat();
            BoatSpace BoatSpaceOne = new WaterSpace(9001, 4, 2);
            BoatOne.BoatSpace = null;
            BoatSpaceOne.Boat = null;

            BoatOne.BoatSpace = BoatSpaceOne;

            Assert.AreEqual(BoatOne, BoatSpaceOne.Boat);
            Assert.AreEqual(BoatSpaceOne.Boat, BoatOne);
        }
        [TestMethod]
        public void OccupiedBoatToFreeSpace_IsSet()
        {
            Boat BoatOne = new Boat();
            BoatSpace BoatSpaceOne = new WaterSpace(9001, 4, 2);
            BoatSpace BoatSpaceTwo = new WaterSpace(900001, 1,4);

            BoatOne.BoatSpace = BoatSpaceOne;
            BoatSpaceTwo.Boat = null;

            BoatOne.BoatSpace = BoatSpaceTwo;
            Assert.AreEqual(BoatSpaceTwo, BoatOne.BoatSpace);
            Assert.AreEqual(BoatOne, BoatSpaceTwo.Boat);
            Assert.AreEqual(null , BoatSpaceOne.Boat);
        }
        
        [TestMethod]
        public void OccupiedSpaceToFreeBoat_IsSet()
        {
            Boat BoatOne = new Boat();
            Boat BoatTwo = new Boat();
            BoatSpace BoatSpaceOne = new WaterSpace(9001, 4, 2);

            BoatOne.BoatSpace = BoatSpaceOne;

            try
            {
                BoatTwo.BoatSpace = BoatSpaceOne;
            }
            catch(Exception)
            {
                return;
            }
            Assert.Fail("Did not throw an exception");
        }
        [TestMethod]
        public void OccupiedSpaceToSameBoat_IsSet()
        {
            Boat BoatOne = new Boat();
            BoatSpace BoatSpaceOne = new WaterSpace(9001, 4, 2);
            BoatOne.BoatSpace = BoatSpaceOne;

            BoatOne.BoatSpace = BoatSpaceOne;

            Assert.AreEqual(BoatSpaceOne, BoatOne.BoatSpace);
            Assert.AreEqual(BoatOne, BoatSpaceOne.Boat);
        }
    }
}
