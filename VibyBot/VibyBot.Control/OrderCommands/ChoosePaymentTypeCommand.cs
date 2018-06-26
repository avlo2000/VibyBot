using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VibyBot.Persistence.Contracts;
using VibyBot.Persistence.DTO.Additional;

namespace VibyBot.Control.OrderCommands
{
    public class ChoosePaymentTypeCommand : OrderCommand
    {
        public override string Name => @"/getpaymenttype";

        public override Tuple<string, List<string>> OrderExecute(string message, long chatId)
        {
            _currentOrder.Adress = message;
            List<string> labels = new List<string>();
            Tuple<string, List<string>> answer = new Tuple<string, List<string>>("Для оформлення замовлення напишіть /start", labels);
            if (message.Contains("Львів"))
            {
                labels.Clear();
                labels = new List<string> { PaymentType.Cash.Type, PaymentType.CreditCard.Type };
                answer = new Tuple<string, List<string>>("Будь виберіть спосіб оплати. Посилки у Львові віддаються на руки. Номер картки вам повідомить менеджер.", labels);
            }
            else
            {
                labels.Clear();
                labels = new List<string> { PaymentType.Cash.Type, PaymentType.CreditCard.Type };
                answer = new Tuple<string, List<string>>("Будь виберіть спосіб оплати. Готівкою при отриманні, або передоплата на банківську картку. Номер картки вам повідомить менеджер.", labels);
            }
            return answer;
        }

        public override bool Contains(string command)
        {
            return command.Contains("м.") || command.Contains("місто") || command.Contains("смт") || command.Contains("селище міського типу") || command.Contains("село");
        }

        public ChoosePaymentTypeCommand(IManagementStorage managementStorage, IAdminStorage userStorage, IOrderStorage orderStorage)
           : base(managementStorage, userStorage, orderStorage)
        {
        }
    }
}
