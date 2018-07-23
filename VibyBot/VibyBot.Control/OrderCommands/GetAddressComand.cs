using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VibyBot.Persistence.Contracts;
using VibyBot.Persistence.DTO;

namespace VibyBot.Control.OrderCommands
{
    public class GetAddressComand : OrderCommand
    {
        public override string Name => @"/chooseplace";

        public override Answer Execute(string message, long chatId)
        {
            List<string> labels = new List<string>();
            Tuple<string, List<string>> answer = new Tuple<string, List<string>>("Для оформлення замовлення напишіть /start", labels);


            _currentOrder.Name = message;
            answer = new Tuple<string, List<string>>("Будь ласка через крапку з комою(;) введіть назву області назву населеного пункту та номер відділення Нової Пошти", labels);

            return new Answer(answer.Item1, answer.Item2);
        }

        public override bool Contains(string command)
        {
            string[] pip = command.Split(' ');
            return pip.Length == 3;
        }

        public GetAddressComand(IManagementStorage managementStorage, IAdminStorage userStorage, IOrderStorage orderStorage)
           : base(managementStorage, userStorage, orderStorage)
        {
        }
    }
}
