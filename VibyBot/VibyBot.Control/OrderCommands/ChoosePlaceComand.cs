using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VibyBot.Persistence.Contracts;

namespace VibyBot.Control.OrderCommands
{
    public class ChoosePlaceComand : OrderCommand
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
                labels.Clear();
                labels = new List<string>() { "Львів", "Інший населений пункт" };
                answer = new Tuple<string, List<string>>("Виберіть населений пункт. У Львові оплата готівкою при отриманні на руки, в інші населені пункти доставка Новою Поштою", labels);
            }
            return answer;
        }

        public override bool Contains(string command)
        {
            string[] pip = command.Split(' ');
            return pip.Length == 3;
        }

        public ChoosePlaceComand(IManagementStorage managementStorage, IOrderStorage orderStorage)
           : base(managementStorage, orderStorage)
        {
        }
    }
}
