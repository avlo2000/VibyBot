using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VibyBot.Control.AdminCommands;
using VibyBot.ControlTests.Mockups;
using VibyBot.Persistence.DTO;

namespace VibyBot.ControlTests.CommandTest
{
    [TestClass]
    public class RemovePrintCommandTest
    {
        public ManagementStorageMock msi;
        public AdminStorageMock asi;
        public OrderStorageMock osi;

        public RemovePrintCommand AccessCommand;

        public RemovePrintCommandTest()
        {
            msi = new ManagementStorageMock();

            ManagerInfo mi = new ManagerInfo();
            mi.Prints = new HashSet<string>{ "123", "456", "789" };
            msi.UpdateConfig(mi);

            asi = new AdminStorageMock();

            asi.SetAdminAccess(777);

            osi = new OrderStorageMock();
            AccessCommand = new RemovePrintCommand(msi, asi, osi);
        }

        [TestMethod]
        public void ExecuteTestTrue()
        {
            string answer = "Принт видалено.";
            string message = @"/rmprint 123";
            long chatId = 777;
            Assert.AreEqual(answer, AccessCommand.Execute(message, chatId));
        }
        [TestMethod]
        public void ExecuteTestFalse()
        {
            string answer = "Немає дозволу.";
            string message = @"/rmprint 123";
            long chatId = 666;
            Assert.AreEqual(answer, AccessCommand.Execute(message, chatId));
        }
    }
}
