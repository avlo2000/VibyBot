using System;
using System.Threading.Tasks;
using Telegram.Bot;
using VibyBot.Persistence.Contracts;
using VibyBot.Persistence.DTO;

namespace VibyBot.Control
{
    public class OrderSender
    {
        private IOrderStorage _orderStorage;
        private IUserStorage _userStorage;

        private string OrderToStr(Order order)
        {
            string stringOrder = "";

            stringOrder = "Замовлення у VIBY shop " + Environment.NewLine;
            stringOrder += "Користувач: " + order.Name + Environment.NewLine;
            stringOrder += "Тип одягу: " + order.ClothesType.Type + Environment.NewLine;
            stringOrder += "Колір одягу: " + order.ClothesColor.Color + Environment.NewLine;
            stringOrder += "Адресса: " + order.Adress + Environment.NewLine;
            stringOrder += "Споіб оплати: " + order.Payment.Type + Environment.NewLine;

            return stringOrder;
        }

        public async Task SendAsync(TelegramBotClient client)
        {
            var managerIds = _userStorage.GetAllAdmins();
            var orders = _orderStorage.GetAll();
            foreach (var id in managerIds)
                foreach (var order in orders)
                    if (order.Ready)
                        await client.SendTextMessageAsync(id, OrderToStr(order));
        }

        public OrderSender(IOrderStorage orderStorage, IUserStorage userStorage)
        {
            _orderStorage = orderStorage;
            _userStorage = userStorage;
        }
    }
}
