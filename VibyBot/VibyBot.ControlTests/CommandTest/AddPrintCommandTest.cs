using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VibyBot.Control.AdminCommands;
using VibyBot.ControlTests.Mockups;
using VibyBot.Persistence.DTO;

namespace VibyBot.ControlTests.CommandTest
{
    [TestClass]
    public class AddPrintCommandTest
    {

        public IManagementStorageImplementation msi;
        public IAdminStorageImplementation asi;
        public IOrderStorageImplementation osi;

        public AddPrintCommand AccessCommand;

        public AddPrintCommandTest()
        {
            msi = new IManagementStorageImplementation();

            ManagerInfo mi = new ManagerInfo
            {
                Password = "123"
            };
            msi.UpdateConfig(mi);

            asi = new IAdminStorageImplementation();

            asi.SetAdminAccess(777);

            osi = new IOrderStorageImplementation();
            AccessCommand = new AddPrintCommand(msi, asi, osi);
        }

        [TestMethod]
        public void ExecuteTestTrue()
        {
            string answer = "Принт додано.";
            string message = @"/addprint 123";
            long chatId = 777;
            Assert.AreEqual(answer, AccessCommand.Execute(message, chatId));
        }
        [TestMethod]
        public void ExecuteTestFalse()
        {
            string answer = "Немає дозволу.";
            string message = @"/addprint 123";
            long chatId = 666;
            Assert.AreEqual(answer, AccessCommand.Execute(message, chatId));
        }
    }
}
