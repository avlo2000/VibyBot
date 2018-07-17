using VibyBot.Persistence.Contracts;
using VibyBot.Persistence.DTO;

namespace VibyBot.Control.AdminCommands
{
    public class AddPrintCommand : AdminCommand
    {
        public override string Name => @"/addprint ";

        public override Answer Execute(string message, long chatId)
        {
            var splCommand = message.Split(' ');
            string answer;

            if (_adminStorage.GetAdminAccess(chatId))
            {
                var print = "";
                for (int i = 1; i < splCommand.Length; i++)
                    print += splCommand[i] + " ";
                _managerInfo.Prints.Add(print);
                answer = "Принт додано.";
            }
            else
                answer = "Немає дозволу.";

            _managementStorage.UpdateConfig(_managerInfo);
            return new Answer(answer);
        }

        public AddPrintCommand(IManagementStorage managementStorage, IAdminStorage userStorage, IOrderStorage orderStorage)
            : base(managementStorage, userStorage, orderStorage)
        {
        }
    }
}
