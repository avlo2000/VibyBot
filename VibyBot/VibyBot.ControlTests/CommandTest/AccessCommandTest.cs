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
        public ManagementStorageMock msi;
        public AdminStorageMock asi;
        public OrderStorageMock osi;

        public AccessCommand AccessCommand;

        public AccessCommandTest()
        {
            msi = new ManagementStorageMock();

            ManagerInfo mi = new ManagerInfo
            {
                Password = "123"
            };
            msi.UpdateConfig(mi);

            asi = new AdminStorageMock();
            osi = new OrderStorageMock();
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
