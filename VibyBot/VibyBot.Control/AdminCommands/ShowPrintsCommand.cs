using System;
using VibyBot.Persistence.Contracts;

namespace VibyBot.Control.AdminCommands
{
    public class ShowPrintsCommand : AdminCommand
    {
        public override string Name => @"/showprints";

        public override string Execute(string message, long chatId)
        {
            string answer = "Дотупні принти:" + Environment.NewLine;

            int couter = 1;
            foreach (var print in _managerInfo.Prints)
            {
                answer += couter.ToString() + @") ";
                answer += print;
                answer += Environment.NewLine;
                couter++;
            }

            return answer;
        }

        public ShowPrintsCommand(IManagementStorage managementStorage, IAdminStorage userStorage, IOrderStorage orderStorage)
            : base(managementStorage, userStorage, orderStorage)
        {
        }
    }
}
