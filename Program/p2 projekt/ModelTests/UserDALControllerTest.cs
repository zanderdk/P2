using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using p2_projekt.models;
using p2_projekt;
using System.Data.Entity;
using Moq;
using System.Linq;

namespace ModelTests
{
    [TestClass]
    public class UserDALControllerTest
    {
        Member alice;
        Mock<IDAL> MockIDAL;
        DALController MockController;
        IDAL RealIDAL;
        DALController RealController;

        [TestCleanup]
        public void Teardown()
        {
            using (var db = new LobopContext())
            {
                db.Database.Delete();
                db.SaveChanges();
            }
        }


        [TestInitialize]
        public void Setup()
        {
            //alice = new Member("Alice", new System.Device.Location.CivicAddress());
            //alice.Birthday = new DateTime(2013, 1, 1);
            //alice.RegistrationDate = new DateTime(2013, 1, 1);

            BoatSpace bs = new WaterSpace(10.0, 10.0) { Info = "dfgdfg" };
            Boat b = new Boat() { Name = "test Ship", BoatSpace = bs, RegistrationNumber = "fdsf" };
            Travel travel = new Travel(new DateTime(2008, 1, 1), new DateTime(2001, 1, 1));
            alice = new Member("Kasper", new System.Device.Location.CivicAddress()) { Password = "test" };
            //alice.Permission = new Permission() { search = true };
            //alice.Travels.Add(travel);
            alice.Birthday = new DateTime(2013, 1, 1);
            alice.RegistrationDate = new DateTime(2013, 1, 1);
            
            MockIDAL = new Mock<IDAL>();
            MockController = new DALController(MockIDAL.Object);

            RealIDAL = new Utilities.Database();
            RealController = new DALController(RealIDAL);
        }

        [TestMethod]
        public void Add_UserDoesNotExist_True()
        {
            MockIDAL.Setup(x => x.Create(alice));
            
            bool expected = true;
            bool actual = MockController.Add(alice);

            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void Remove_UserExists_True()
        {
            MockIDAL.Setup(x => x.Delete(alice));

            bool expected = true;
            bool actual = MockController.Remove(alice);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Find_ObjectExists_ObjectFound()
        {
            //userDAL.Setup(x => x.Read(1)).Returns(alice);

        }

        [TestMethod]
        public void Remove_UserDoesNotExists_False()
        {
            MockIDAL.Setup(x => x.Delete(alice)).Throws(new InvalidOperationException());

            bool expected = false;
            bool actual = MockController.Remove(alice);

            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void GetNextMembershipNumber_NoStateChanged_ReturnsNextUniqueNumber()
        {
            //alice = new Member("Alice", new System.Device.Location.CivicAddress());
            RealController.Add<User>(alice);
            Member bob = new Member("Bob", new System.Device.Location.CivicAddress());

            int expected = alice.MembershipNumber + 1;
            int actual = bob.MembershipNumber;

            

            Assert.AreEqual(expected,actual);
        }
    }
}
