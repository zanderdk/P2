using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using p2_projekt.models;

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
            
            alice.Permission.MemberInfo = PermissionLevel.Read;

            bool expected = true;

            bool actual = alice.Permission.CanRead(alice.Permission.MemberInfo);

            Assert.AreEqual(expected, actual);
        }
    }
}
