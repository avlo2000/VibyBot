using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VibyBot.Persistence.Contracts;

namespace VibyBot.Control.OrderCommands
{
    public class ChoosePrintCommand : OrderCommand
    {
        public override string Name => @"/chooseprint";

        public override Tuple<string, List<string>> OrderExecute(string message, long chatId)
        {
            List<string> labels = new List<string>();
            Tuple<string, List<string>> answer = new Tuple<string, List<string>>("Для оформлення замовлення напишіть /start", labels);
            if (message.Contains("Футболка") || message.Contains("Поло") || message.Contains("Кепка"))
            {
                labels.Clear();

                foreach (string print in _managementStorage.GetConfig().Prints)
                {
                    labels.Add(print);
                }
                answer = new Tuple<string, List<string>>("З яким принтом ви бажаєте придбати?", labels);
            }
            return answer;
        }

        public override bool Contains(string command)
        {
            return command.Contains("Футболка") || command.Contains("Поло") || command.Contains("Кепка");
        }

        public ChoosePrintCommand(IManagementStorage managementStorage)
           : base(managementStorage)
        {
        }
    }
}
