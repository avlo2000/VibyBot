using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VibyBot.ControlTests.Mockups;

namespace VibyBot.ControlTests.Mockups
{
    [TestClass]
    public class AdminStorageTest
    {
        private IAdminStorageImplementation _admins;

        public AdminStorageTest()
        {
            _admins = new IAdminStorageImplementation();
            _admins.SetAdminAccess(777);
            _admins.SetAdminAccess(555);
            _admins.SetAdminAccess(999);
        }

        [TestMethod]
        public void GetAdminTestTrue()
        {
            Assert.AreEqual(true, _admins.GetAdminAccess(777));
        }

        [TestMethod]
        public void GetAdminTestFalse()
        {
            Assert.AreEqual(false, _admins.GetAdminAccess(666));
        }

    }
}
