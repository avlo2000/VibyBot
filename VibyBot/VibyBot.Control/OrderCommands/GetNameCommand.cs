using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VibyBot.Persistence.Contracts;

namespace VibyBot.Control.OrderCommands
{
    public class GetNameCommand : OrderCommand
    {
        public override string Name => @"/getname";

        public override Tuple<string, List<string>> OrderExecute(string message, long chatId)
        {
            List<string> labels = new List<string>();
            Tuple<string, List<string>> answer = new Tuple<string, List<string>>("Для оформлення замовлення напишіть /start", labels);
            if (message.Contains("+380") && message.Length == 13)
            {
                _currentOrder.PhoneNumber = message;
                answer = new Tuple<string, List<string>>("Введіть через пробіл свій ПІП(прізвище, ім'я, по батькові) будь ласка" + Environment.NewLine + "Наприклад Петров Петро Петрович. Будь ласка не вводьте жодних додаткових символів", labels);
            }
            return answer;
        }

        public override bool Contains(string command)
        {
            return command.Contains("+380") && command.Length == 13;
        }

        public GetNameCommand(IManagementStorage managementStorage, IOrderStorage orderStorage)
           : base(managementStorage, orderStorage)
        {
        }

    }
}
