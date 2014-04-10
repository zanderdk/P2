﻿using System;
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
        Mock<IDAL> userDAL;
        UserController controller;

        [TestInitialize]
        public void Setup()
        {
            alice = new Member("Alice", new System.Device.Location.CivicAddress());
            alice.UserId = 1;
            alice.Birthday = new DateTime(2013, 1, 1);
            userDAL = new Mock<IDAL>();
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
        public void Remove_UserExists_True()
        {
            userDAL.Setup(x => x.Delete(alice));

            bool expected = true;
            bool actual = controller.Remove(alice);

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
            userDAL.Setup(x => x.Delete(alice)).Throws(new InvalidOperationException());

            bool expected = false;
            bool actual = controller.Remove(alice);

            Assert.AreEqual(expected, actual);
        }


        //[TestMethod]
        //public void GetNextMembershipNumber_NoStateChanged_ReturnsNextUniqueNumber()
        //{
        //    Member alice = new Member();

            
        //    int aliceNum = alice.MembershipNumber;

        //    Member bob = new Member();

        //    Assert.AreEqual(aliceNum + 1, bob.MembershipNumber);
        //}
    }
}
