using VibyBot.Persistence.Contracts;
using VibyBot.Persistence.DTO;

namespace VibyBot.Control.AdminCommands
{
    public class RemovePrintCommand : AdminCommand
    {
        public override string Name => @"/rmprint ";

        public override Answer Execute(string message, long chatId)
        {
            var splCommand = message.Split(' ');
            string answer;

            if (_adminStorage.GetAdminAccess(chatId))
            {
                var print = "";
                for (int i = 1; i < splCommand.Length; i++)
                    print += splCommand[i] + " ";
                if (_managerInfo.Prints.Remove(print))
                    answer = "Принт видалено.";
                else
                    answer = "Принт не знайдено.";
            }
            else
                answer = "Немає дозволу.";

            _managementStorage.UpdateConfig(_managerInfo);

            return new Answer(answer);
        }

        public RemovePrintCommand(IManagementStorage managementStorage, IAdminStorage userStorage, IOrderStorage orderStorage)
            : base(managementStorage, userStorage, orderStorage)
        {
        }
    }
}
