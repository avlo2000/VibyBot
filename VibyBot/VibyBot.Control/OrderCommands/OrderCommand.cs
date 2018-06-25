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

        abstract public Tuple<string, List<string>> OrderExecute(string message, long chatId);

        string ICommand.Execute(string message, long chatId)
        {
            throw new NotImplementedException();
        }

        public virtual bool Contains(string command)
        {
            return command.Contains(Name);
        }

        protected Order _currentOrder;

        protected IManagementStorage _managementStorage;
        protected IOrderStorage _orderStorage;
        protected ManagerInfo _managerInfo;

        public OrderCommand(IManagementStorage managementStorage, IOrderStorage orderStorage)
        {
            _managerInfo = managementStorage.GetConfig();
            _managementStorage = managementStorage;
            _orderStorage = orderStorage;
        }

    }
}
