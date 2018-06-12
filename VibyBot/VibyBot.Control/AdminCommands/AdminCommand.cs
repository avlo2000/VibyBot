using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using VibyBot.Persistence.Contracts;
using VibyBot.Persistence.DTO;

namespace VibyBot.Control.AdminCommands
{
    abstract public class AdminCommand
    {
        public abstract string Name { get; }

        abstract public Task ExecuteAsync(Message message, TelegramBotClient client);

        public string Answer { get; protected set; }

        

        public virtual bool Contains(string command)
        {
            return command.Contains(Name);
        }

        protected ManagerInfo _managerInfo;

        protected IManagementStorage _managementStorage;
        protected IAdminStorage _adminStorage;
        protected IOrderStorage _orderStorage;

        public AdminCommand(IManagementStorage managementStorage, IAdminStorage userStorage, IOrderStorage orderStorage)
        {
            _managerInfo = _managementStorage.GetConfig();
            _managementStorage = managementStorage;
            _orderStorage = orderStorage;
            _adminStorage = userStorage;
        }
    }
}
