using System;
using System.Threading.Tasks;
using Telegram.Bot;
using VibyBot.Persistence.Contracts;
using VibyBot.Persistence.DTO;

namespace VibyBot.TelegramAPI.Models
{
    public class OrderSender
    {
        private IOrderStorage _orderStorage;
        private IAdminStorage _userStorage;

        private string OrderToStr(Order order)
        {
            string stringOrder = "";

            stringOrder = "Замовлення у VIBY shop " + Environment.NewLine;
            stringOrder += "Користувач: " + order.Name + Environment.NewLine;
            stringOrder += "Тип одягу: " + order.ClothesType.Type + Environment.NewLine;
            stringOrder += "Колір одягу: " + order.ClothesColor.Color + Environment.NewLine;
            stringOrder += "Номер телефону: " + order.PhoneNumber + Environment.NewLine;
            stringOrder += "Адресса: " + order.Adress + Environment.NewLine;
            stringOrder += "Споіб оплати: " + order.Payment.Type + Environment.NewLine;

            return stringOrder;
        }

        public async Task SendOrderAsync(TelegramBotClient client, long chatId, Order order)
        {
            await client.SendTextMessageAsync(chatId, OrderToStr(order));
        }

        public async Task SendToAllAsync(TelegramBotClient client)
        {
            var managerIds = _userStorage.GetAllAdmins();
            var orders = _orderStorage.GetAll();
            foreach (var id in managerIds)
                foreach (var order in orders)
                    if (order.Ready)
                        await SendOrderAsync(client, id, order);
        }

        public OrderSender(IOrderStorage orderStorage, IAdminStorage userStorage)
        {
            _orderStorage = orderStorage;
            _userStorage = userStorage;
        }
    }
}
