using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VibyBot.Control.AdminCommands;
using VibyBot.ControlTests.Mockups;
using VibyBot.Persistence.DTO;

namespace VibyBot.ControlTests.CommandTest
{
    [TestClass]
    public class CloseOrderTest
    {
        public ManagementStorageMock msi;
        public AdminStorageMock asi;
        public OrderStorageMock osi;

        public CloseOrderCommand AccessCommand;

        public CloseOrderTest()
        {
            msi = new ManagementStorageMock();

            ManagerInfo mi = new ManagerInfo
            {
                Password = "123"
            };
            msi.UpdateConfig(mi);

            asi = new AdminStorageMock();

            asi.SetAdminAccess(777);

            osi = new OrderStorageMock();
            AccessCommand = new CloseOrderCommand(msi, asi, osi);
        }

        [TestMethod]
        public void ExecuteTestTrue()
        {
            osi.UpdateOrder(new Order(1) { OrderId = 1});
            osi.UpdateOrder(new Order(2) { OrderId = 2 });
            osi.UpdateOrder(new Order(3) { OrderId = 3 });
            osi.UpdateOrder(new Order(4) { OrderId = 4 });
            osi.UpdateOrder(new Order(4) { OrderId = 5 });

            var answer = "Замовлення закрито.";

            Assert.AreEqual(answer, AccessCommand.Execute(@"/close 2", 777));
        }
    }
}
