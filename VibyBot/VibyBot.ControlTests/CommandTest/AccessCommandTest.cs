using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VibyBot.Control.AdminCommands;
using VibyBot.ControlTests.Mockups;
using VibyBot.Persistence.DTO;

namespace VibyBot.ControlTests.CommandTest
{
    [TestClass]
    public class AccessCommandTest
    {
        public IManagementStorageImplementation msi;
        public IAdminStorageImplementation asi;
        public IOrderStorageImplementation osi;

        public AccessCommand AccessCommand;

        public AccessCommandTest()
        {
            msi = new IManagementStorageImplementation();

            ManagerInfo mi = new ManagerInfo
            {
                Password = "123"
            };
            msi.UpdateConfig(mi);

            asi = new IAdminStorageImplementation();
            osi = new IOrderStorageImplementation();
            AccessCommand= new AccessCommand(msi, asi, osi);
        }

        [TestMethod]
        public void ContainTest()
        {
            string s = @"/admin 123";
            Assert.AreEqual(true, AccessCommand.Contains(s));
        }

        [TestMethod]
        public void ExecuteTest()
        {
            string answer = "Доступ  дозволено.";
            string message = @"/admin 123";
            long chatId = 777;
            Assert.AreEqual(answer, AccessCommand.Execute(message, chatId));
        }
    }
}
