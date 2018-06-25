using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VibyBot.Persistence.Contracts;
using VibyBot.Persistence.DTO;
using VibyBot.Persistence.DTO.Additional;

namespace VibyBot.Control.OrderCommands
{
    public class ChooseTypeCommand : OrderCommand
    {
        public override string Name => @"/choosetype";

        public override Tuple<string, List<string>> OrderExecute(string message, long chatId)
        {
            List<string> labels = new List<string>();
            Tuple<string, List<string>> answer = new Tuple<string, List<string>>("Для оформлення замовлення напишіть /start", labels);
            if (message.Contains("Так"))
            {
                _currentOrder = new Order(chatId);
                _currentOrder.OrderId = _currentOrder.GetHashCode()+message.GetHashCode()+chatId.GetHashCode();

                labels.Clear();
                labels = new List<string>() { ClothesType.Cap.Type, ClothesType.Polo.Type, ClothesType.Tshirt.Type };
                answer = new Tuple<string, List<string>>("Що ви бажаєте придбати?", labels);
            }
            return answer;
        }

        public override bool Contains(string command)
        {
            return command.Contains("Так") || command.Contains("Ні");
        }

        public ChooseTypeCommand(IManagementStorage managementStorage, IOrderStorage orderStorage)
           : base(managementStorage, orderStorage)
        {
        }
    }
}