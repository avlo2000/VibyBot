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
    public class ChoosePrintCommand : OrderCommand
    {
        public override string Name => @"/chooseprint";

        public override Answer Execute(string message, long chatId)
        {
            List<string> labels = new List<string>();
            Tuple<string, List<string>> answer = new Tuple<string, List<string>>("Для оформлення замовлення напишіть /start", labels);
            if (message.Contains(ClothesColor.Black.Color))
            {
                _currentOrder.ClothesColor = ClothesColor.Black;
                labels.Clear();
                foreach (string print in _managementStorage.GetConfig().Prints)
                {
                    labels.Add(print);
                }
                answer = new Tuple<string, List<string>>("Виріб з яким принтом ви бажаєте замовити?", labels);
            }

            if (message.Contains(ClothesColor.White.Color))
            {
                _currentOrder.ClothesColor = ClothesColor.White;
                labels.Clear();
                if (_currentOrder.ClothesType.Type == ClothesType.Tshirt.Type)
                {
                    foreach (string print in _managementStorage.GetConfig().Prints)
                    {
                        labels.Add(print);
                    }
                    answer = new Tuple<string, List<string>>("Виріб з яким принтом ви бажаєте замовити?", labels);
                }
                if (_currentOrder.ClothesType.Type == ClothesType.Polo.Type)
                {
                    foreach (string print in _managementStorage.GetConfig().Prints)
                    {
                        labels.Add(print);
                    }
                    answer = new Tuple<string, List<string>>("Виріб з яким принтом ви бажаєте замовити?", labels);
                }
            }

            if (message.Contains(ClothesColor.Yellow.Color))
            {
                _currentOrder.ClothesColor = ClothesColor.Yellow;
                labels.Clear();
                if (_currentOrder.ClothesType.Type == ClothesType.Tshirt.Type)
                {
                    foreach (string print in _managementStorage.GetConfig().Prints)
                    {
                        labels.Add(print);
                    }
                    answer = new Tuple<string, List<string>>("Виріб з яким принтом ви бажаєте замовити?", labels);
                }
            }

            return new Answer(answer.Item1, answer.Item2);
        }

        public override bool Contains(string command)
        {
            return command.Contains(ClothesColor.Black.Color) || command.Contains(ClothesColor.White.Color) || command.Contains(ClothesColor.Yellow.Color);
        }

        public ChoosePrintCommand(IManagementStorage managementStorage, IAdminStorage userStorage, IOrderStorage orderStorage)
           : base(managementStorage, userStorage, orderStorage)
        {
        }
    }
}