using VibyBot.Persistence.Contracts;
using VibyBot.Persistence.DTO;

namespace VibyBot.Control.AdminCommands
{
    public class CloseOrderCommand : AdminCommand
    {
        public override string Name => @"/close ";

        public override Answer Execute(string message, long chatId)
        {
            var splCommand = message.Split(' ');
            var orderId = int.Parse(splCommand[1]);
            string answer;
            if (_adminStorage.GetAdminAccess(chatId))
            {
                _orderStorage.CloseOrder(orderId);
                answer = "Замовлення закрито.";
            }
            else
                answer = "Немає дозволу.";

            return new Answer(answer);
        }

        public CloseOrderCommand(IManagementStorage managementStorage, IAdminStorage userStorage, IOrderStorage orderStorage)
            : base(managementStorage, userStorage, orderStorage)
        {
        }
    }
}
