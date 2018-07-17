using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VibyBot.Control.AdminCommands;
using VibyBot.ControlTests.Mockups;
using VibyBot.Persistence.DTO;

namespace VibyBot.ControlTests.CommandTest
{
    [TestClass]
    public class ShowPrintsCommandTest
    {
        public ManagementStorageMock msi;
        public AdminStorageMock asi;
        public OrderStorageMock osi;

        public ShowPrintsCommand AccessCommand;

        public ShowPrintsCommandTest()
        {
            msi = new ManagementStorageMock();

            ManagerInfo mi = new ManagerInfo
            {
                Password = "123",
                Prints = new HashSet<string>() { "123", "456", "789" }
            };
            msi.UpdateConfig(mi);

            asi = new AdminStorageMock();

            asi.SetAdminAccess(777);

            osi = new OrderStorageMock();
            AccessCommand = new ShowPrintsCommand(msi, asi, osi);
        }

        [TestMethod]
        public void ExecuteTest()
        {
            string answer = "Дотупні принти:" + Environment.NewLine;
            int counter = 0;
            foreach (var print in msi.GetConfig().Prints)
            {
                counter++;
                answer = answer + counter + ") ";
                answer += print;
                answer += Environment.NewLine;
            }

            string message = @"/showprints";
            long chatId = 777;
            Assert.AreEqual(answer, AccessCommand.Execute(message, chatId));
        }
    }
}