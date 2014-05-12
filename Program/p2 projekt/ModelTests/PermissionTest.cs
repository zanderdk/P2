using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using p2_projekt.models;
using p2_projekt.Enums;

namespace ModelTests
{
    [TestClass]
    public class PermissionTest
    {
        Member alice;

        [TestInitialize]
        public void Setup()
        {
            alice = new Member("Alice", new System.Device.Location.CivicAddress());
        }

        [TestMethod]
        public void PermissionLevelTest_UserCanRead_True()
        {
            alice.Permission = new Permission {PersonalInfo = PermissionLevel.Read};

            bool expected = true;

            bool actual = Permission.CanRead(alice.Permission.PersonalInfo);

            Assert.AreEqual(expected, actual);
        }
    }
}
