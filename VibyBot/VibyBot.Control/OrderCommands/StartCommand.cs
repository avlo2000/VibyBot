using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VibyBot.Persistence.Contracts;
using VibyBot.Persistence.DTO;

namespace VibyBot.Control.OrderCommands
{
    public class StartCommand : OrderCommand
    {
        public override string Name => @"/start";

        public override Tuple<string, List<string>> OrderExecute(string message, long chatId)
        {
            List<string> labels = new List<string>() { "Так", "Ні" };
            var answer = new Tuple<string, List<string>>("Ви бажаєте зробити замовлення?", labels);
            return answer;
        }

        public StartCommand(IManagementStorage managementStorage, IAdminStorage userStorage, IOrderStorage orderStorage)
            : base(managementStorage, userStorage, orderStorage)
        {
        }

    }
}
