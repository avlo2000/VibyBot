using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VibyBot.Persistence.Contracts;
using VibyBot.Persistence.DTO.Additional;

namespace VibyBot.Control.OrderCommands
{
    public class ChooseColorCommand : OrderCommand
    {
        public override string Name => @"/choosecolor";

        public override Tuple<string, List<string>> OrderExecute(string message, long chatId)
        {
            List<string> labels = new List<string>();
            Tuple<string, List<string>> answer = new Tuple<string, List<string>>("Для оформлення замовлення напишіть /start", labels);
            if (message.Contains(ClothesType.Cap.Type))
            {
                _currentOrder.ClothesType = ClothesType.Cap;
                labels.Clear();
                labels = new List<string>() { ClothesColor.Black.Color };
                answer = new Tuple<string, List<string>>("Якого кольору вибір ви бажаєте придбати?", labels);
            }

            if (message.Contains(ClothesType.Polo.Type))
            {
                _currentOrder.ClothesType = ClothesType.Polo;
                labels.Clear();
                labels = new List<string>() { ClothesColor.Black.Color, ClothesColor.White.Color };
                answer = new Tuple<string, List<string>>("Якого кольору вибір ви бажаєте придбати?", labels);
            }
            if (message.Contains(ClothesType.Tshirt.Type))
            {
                _currentOrder.ClothesType = ClothesType.Tshirt;
                labels.Clear();
                labels = new List<string>() { ClothesColor.Black.Color, ClothesColor.White.Color, ClothesColor.Yellow.Color };
                answer = new Tuple<string, List<string>>("Якого кольору вибір ви бажаєте придбати?", labels);
            }
            return answer;
        }

        public override bool Contains(string command)
        {
            return command.Contains(ClothesType.Cap.Type) || command.Contains(ClothesType.Polo.Type) || command.Contains(ClothesType.Tshirt.Type);
        }

        public ChooseColorCommand(IManagementStorage managementStorage, IAdminStorage userStorage, IOrderStorage orderStorage)
            : base(managementStorage, userStorage, orderStorage)
        {

        }
    }
}
