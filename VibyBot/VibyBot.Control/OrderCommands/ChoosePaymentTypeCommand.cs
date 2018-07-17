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
    public class ChoosePaymentTypeCommand : OrderCommand
    {
        public override string Name => @"/getpaymenttype";

        public override Answer Execute(string message, long chatId)
        {
            _currentOrder.Adress = message;

            string[] address = message.Split(';');

            List<string> labels = new List<string>();
            Tuple<string, List<string>> answer = new Tuple<string, List<string>>("Для оформлення замовлення напишіть /start", labels);
            if (address[1].Contains("Львів"))
            {
                labels.Clear();
                labels = new List<string> { PaymentType.Cash.Type, PaymentType.CreditCard.Type };
                answer = new Tuple<string, List<string>>("Виберіть спосіб оплати. Посилки у Львові віддаються на руки. Номер картки вам повідомить менеджер.", labels);
            }
            else
            {
                labels.Clear();
                labels = new List<string> { PaymentType.Cash.Type, PaymentType.CreditCard.Type };
                answer = new Tuple<string, List<string>>("Виберіть спосіб оплати. Готівкою при отриманні, або передоплата на банківську картку. Номер картки вам повідомить менеджер.", labels);
            }
            return new Answer(answer.Item1, answer.Item2);
        }

        public override bool Contains(string command)
        {
            string[] address = command.Split(';');
            return address.Length == 3 && address[0].Contains("ька");
        }

        public ChoosePaymentTypeCommand(IManagementStorage managementStorage, IAdminStorage userStorage, IOrderStorage orderStorage)
           : base(managementStorage, userStorage, orderStorage)
        {
        }
    }
}
