using VibyBot.Persistence.Contracts;
using VibyBot.Persistence.DTO;

namespace VibyBot.Control.AdminCommands
{
    abstract public class AdminCommand : StorageControl, ICommand
    {
        public abstract string Name { get; }

        abstract public string Execute(string message, long chatId);

        public virtual bool Contains(string command)
        {
            return command.Contains(Name);
        }

        protected IManagementStorage _managementStorage;
        protected IAdminStorage _adminStorage;
        protected IOrderStorage _orderStorage;
        protected ManagerInfo _managerInfo;

        public AdminCommand(IManagementStorage managementStorage, IAdminStorage userStorage, IOrderStorage orderStorage)
        {
            _managerInfo = _managementStorage.GetConfig();
            _managementStorage = managementStorage;
            _orderStorage = orderStorage;
            _adminStorage = userStorage;
        }
    }
}
