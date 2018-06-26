using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VibyBot.Persistence.Contracts;

namespace VibyBot.Control.OrderCommands
{
    public class GetAddressComand : OrderCommand
    {
        public override string Name => @"/chooseplace";

        public override Tuple<string, List<string>> OrderExecute(string message, long chatId)
        {
            List<string> labels = new List<string>();
            Tuple<string, List<string>> answer = new Tuple<string, List<string>>("Для оформлення замовлення напишіть /start", labels);

            string[] pip = message.Split(' ');
            if (pip.Length == 3)
            {
                _currentOrder.Name = message;
                answer = new Tuple<string, List<string>>("Будь ласка введіть свою адресу.", labels);
            }
            return answer;
        }

        public override bool Contains(string command)
        {
            string[] pip = command.Split(' ');
            return pip.Length == 3;
        }

        public GetAddressComand(IManagementStorage managementStorage, IOrderStorage orderStorage)
           : base(managementStorage, orderStorage)
        {
        }
    }
}
