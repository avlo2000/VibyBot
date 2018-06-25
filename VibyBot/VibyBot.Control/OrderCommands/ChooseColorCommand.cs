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
            foreach (string print in _managementStorage.GetConfig().Prints)
            {
                if (message == print && _currentOrder.ClothesType == ClothesType.Cap)
                {
                    _currentOrder.Print = print;
                    labels = new List<string>() { ClothesColor.Black.Color, ClothesColor.Yellow.Color, ClothesColor.White.Color };
                    answer = new Tuple<string, List<string>>("Якого кольору ви хочете виріб?/start", labels);
                    break;
                }
            }
            return answer;
        }

        public override bool Contains(string command)
        {
            return command.Contains(ClothesColor.Black.Color) || command.Contains(ClothesColor.Yellow.Color) || command.Contains(ClothesColor.White.Color);
        }

        public ChooseColorCommand(IManagementStorage managementStorage, IOrderStorage orderStorage)
            :base(managementStorage, orderStorage)
        {

        }
    }
}
