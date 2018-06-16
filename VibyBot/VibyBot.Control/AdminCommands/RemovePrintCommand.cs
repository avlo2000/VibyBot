using VibyBot.Persistence.Contracts;

namespace VibyBot.Control.AdminCommands
{
    public class RemovePrintCommand : AdminCommand
    {
        public override string Name => @"/rmprint";

        public override string Execute(string message, long chatId)
        {
            var splCommand = message.Split(' ');
            string answer;

            if (_adminStorage.GetAdminAccess(chatId))
            {
                _managerInfo.Prints.Remove(splCommand[1]);
                answer = "Принт видалено.";
            }
            else
                answer = "Немає дозволу.";

            _managementStorage.UpdateConfig(_managerInfo);

            return answer;
        }

        public RemovePrintCommand(IManagementStorage managementStorage, IAdminStorage userStorage, IOrderStorage orderStorage)
            : base(managementStorage, userStorage, orderStorage)
        {
        }
    }
}
