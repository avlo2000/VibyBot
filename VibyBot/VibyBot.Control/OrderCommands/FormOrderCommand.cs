using System;
using System.Collections.Generic;
using VibyBot.Persistence.Contracts;
using VibyBot.Persistence.DTO;
using VibyBot.Persistence.DTO.Additional;

namespace VibyBot.Control.OrderCommands
{
    public class FormOrderCommand : OrderCommand
    {
        public override string Name => @"/formorder";

        public override Answer Execute(string message, long chatId)
        {
            List<string> labels = new List<string>();
            Tuple<string, List<string>> answer = new Tuple<string, List<string>>("Для оформлення замовлення напишіть /start", labels);
            
            if (message.Contains(PaymentType.Cash.Type))
            {
                _currentOrder.Payment = PaymentType.Cash;
                _currentOrder.Ready = true;
                _orderStorage.UpdateOrder(_currentOrder);
                answer = new Tuple<string, List<string>>("Ваше замовлення відправлене. Наш менеджер з вами зв'яжеться.", labels);
            }
            if (message.Contains(PaymentType.CreditCard.Type))
            {
                _currentOrder.Payment = PaymentType.CreditCard;
                _currentOrder.Ready = true;
                _orderStorage.UpdateOrder(_currentOrder);
                answer = new Tuple<string, List<string>>("Ваше замовлення відправлене. Наш менеджер з вами зв'яжеться.", labels);

            }
            return new Answer(answer.Item1, answer.Item2);
        }
        public override bool Contains(string command)
        {
            return command.Contains(PaymentType.Cash.Type) || command.Contains(PaymentType.CreditCard.Type);
        }

        public FormOrderCommand(IManagementStorage managementStorage, IAdminStorage userStorage, IOrderStorage orderStorage)
           : base(managementStorage, userStorage, orderStorage)
        {
        }
    }
}
