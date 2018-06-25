using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VibyBot.Persistence.Contracts;
using VibyBot.Persistence.DTO.Additional;

namespace VibyBot.Control.OrderCommands
{
    public class ChoosePrintCommand : OrderCommand
    {
        public override string Name => @"/chooseprint";

        public override Tuple<string, List<string>> OrderExecute(string message, long chatId)
        {
            List<string> labels = new List<string>();
            Tuple<string, List<string>> answer = new Tuple<string, List<string>>("Для оформлення замовлення напишіть /start", labels);
            if (message.Contains(ClothesType.Tshirt.Type))
            {
                _currentOrder.ClothesType = ClothesType.Tshirt;

                labels.Clear();

                foreach (string print in _managementStorage.GetConfig().Prints)
                {
                    labels.Add(print);
                }
                return answer = new Tuple<string, List<string>>("З яким принтом ви бажаєте придбати футболку?", labels);
            }

            if (message.Contains(ClothesType.Polo.Type))
            {

                _currentOrder.ClothesType = ClothesType.Polo;

                labels.Clear();

                foreach (string print in _managementStorage.GetConfig().Prints)
                {
                    labels.Add(print);
                }
                return answer = new Tuple<string, List<string>>("З яким принтом ви бажаєте придбати поло?", labels);
            }

            if (message.Contains(ClothesType.Cap.Type))
            {

                _currentOrder.ClothesType = ClothesType.Cap;

                labels.Clear();

                foreach (string print in _managementStorage.GetConfig().Prints)
                {
                    labels.Add(print);
                }
                return answer = new Tuple<string, List<string>>("З яким принтом ви бажаєте придбати кепку?", labels);
            }

            return answer;
        }

        public override bool Contains(string command)
        {
            return command.Contains(ClothesType.Cap.Type) || command.Contains(ClothesType.Polo.Type) || command.Contains(ClothesType.Tshirt.Type);
        }

        public ChoosePrintCommand(IManagementStorage managementStorage, IOrderStorage orderStorage)
           : base(managementStorage, orderStorage)
        {
        }
    }
}