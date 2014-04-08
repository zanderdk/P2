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
        Mock<IUserDAL> userDAL;
        UserController controller;

        [TestInitialize]
        public void Setup()
        {
            alice = new Member("Alice", new System.Device.Location.CivicAddress());
            alice.UserId = 1;
            alice.Birthday = new DateTime(2013, 1, 1);
            userDAL = new Mock<IUserDAL>();
            controller = new UserController(userDAL.Object);
        }

        [TestMethod]
        public void Add_UserDoesNotExist_True()
        {
            userDAL.Setup(x => x.Create(alice));
            
            bool expected = true;
            bool actual = controller.Add(alice);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Add_UserAlreadyExists_False()
        {
            userDAL.Setup(x => x.Create(alice)).Throws(new InvalidOperationException());

            bool expected = false;
            bool actual = controller.Add(alice);

            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void Remove_UserExists_Void()
        {

            bool passed = false;
            try
            {
                controller.Remove(alice);
            }
            catch (Exception)
            {
                Assert.Fail("Threw exception. SHould not");
            }
            
        }

        [TestMethod]
        public void GetNextMembershipNumber_NoStateChanged_ReturnsNextUniqueNumber()
        {
            Member alice = new Member();

            
            int aliceNum = alice.MembershipNumber;

            Member bob = new Member();

            Assert.AreEqual(aliceNum + 1, bob.MembershipNumber);
        }
    }
}
