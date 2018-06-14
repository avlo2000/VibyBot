using VibyBot.Persistence.Contracts;

namespace VibyBot.Control.AdminCommands
{
    abstract public class AdminCommand : StorageControl
    {
        public abstract string Name { get; }

        abstract public string Execute(string message, long chatId);

        public virtual bool Contains(string command)
        {
            return command.Contains(Name);
        }

        public AdminCommand(IManagementStorage managementStorage, IAdminStorage userStorage, IOrderStorage orderStorage)
        {
            _managerInfo = _managementStorage.GetConfig();
            _managementStorage = managementStorage;
            _orderStorage = orderStorage;
            _adminStorage = userStorage;
        }
    }
}
