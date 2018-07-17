using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VibyBot.Persistence.Contracts;
using VibyBot.Persistence.DTO;

namespace VibyBot.Control.OrderCommands
{
    abstract public class OrderCommand : ICommand
    {
        public abstract string Name { get; }

        abstract public Answer Execute(string message, long chatId);

        public virtual bool Contains(string command)
        {
            return command.Contains(Name);
        }

        protected static Order _currentOrder;

        protected IManagementStorage _managementStorage;
        protected IAdminStorage _adminStorage;
        protected IOrderStorage _orderStorage;
        protected ManagerInfo _managerInfo;

        public OrderCommand(IManagementStorage managementStorage, IAdminStorage userStorage, IOrderStorage orderStorage)
        {
            _managerInfo = managementStorage.GetConfig();
            _managementStorage = managementStorage;
            _adminStorage = userStorage;
            _orderStorage = orderStorage;
        }

    }
}
