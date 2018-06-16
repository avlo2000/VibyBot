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
        public IManagementStorageImplementation msi;
        public IAdminStorageImplementation asi;
        public IOrderStorageImplementation osi;

        public ShowPrintsCommand AccessCommand;

        public ShowPrintsCommandTest()
        {
            msi = new IManagementStorageImplementation();

            ManagerInfo mi = new ManagerInfo
            {
                Password = "123",
                Prints = new HashSet<string>() { "123", "456", "789" }
            };
            msi.UpdateConfig(mi);

            asi = new IAdminStorageImplementation();

            asi.SetAdminAccess(777);

            osi = new IOrderStorageImplementation();
            AccessCommand = new ShowPrintsCommand(msi, asi, osi);
        }

        [TestMethod]
        public void ExecuteTest()
        {
            string answer = "Дотупні принти:" + Environment.NewLine;

            foreach (var print in msi.GetConfig().Prints)
            {
                answer += print;
                answer += Environment.NewLine;
            }

            string message = @"/showprints";
            long chatId = 777;
            Assert.AreEqual(answer, AccessCommand.Execute(message, chatId));
        }
    }
}