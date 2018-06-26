using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VibyBot.Persistence.Contracts;

namespace VibyBot.Control.OrderCommands
{
    public class GetPhoneNumberCommand : OrderCommand
    {
        public override string Name => @"/getphonenumber";

        public override Tuple<string, List<string>> OrderExecute(string message, long chatId)
        {
            List<string> labels = new List<string>();
            Tuple<string, List<string>> answer = new Tuple<string, List<string>>("Для оформлення замовлення напишіть /start", labels);
            foreach (string print in _managementStorage.GetConfig().Prints)
            {
                if (message.Contains(print))
                {
                    _currentOrder.Print = print;
                    answer = new Tuple<string, List<string>>("Введіть свій номер телефону будь ласка.", labels);
                    break;
                }
            }
            return answer;
        }
        public override bool Contains(string command)
        {
            bool result=false;
            foreach (string print in _managementStorage.GetConfig().Prints)
            {
                if (command.Contains(print))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        public GetPhoneNumberCommand(IManagementStorage managementStorage, IAdminStorage userStorage, IOrderStorage orderStorage)
           : base(managementStorage, userStorage, orderStorage)
        {
        }
    }
}
