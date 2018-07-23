using System;
using System.Threading.Tasks;
using Telegram.Bot;
using VibyBot.Control;
using VibyBot.Persistence.Contracts;
using VibyBot.Persistence.DTO;

namespace VibyBot.TelegramAPI.Models
{
    public class OrderSender : IOrderSender
    {
        private IOrderStorage _orderStorage;
        private IAdminStorage _userStorage;
        private TelegramBotClient _client;

        private string OrderToStr(Order order)
        {
            string stringOrder;

            stringOrder = "Замовлення у VIBY shop " + Environment.NewLine;
            stringOrder += "Користувач: " + order.Name + Environment.NewLine;
            stringOrder += "Тип одягу: " + order.ClothesType.Type + Environment.NewLine;
            stringOrder += "Колір одягу: " + order.ClothesColor.Color + Environment.NewLine;
            stringOrder += "Номер телефону: " + order.PhoneNumber + Environment.NewLine;
            stringOrder += "Адресса: " + order.Adress + Environment.NewLine;
            stringOrder += "Споіб оплати: " + order.Payment.Type + Environment.NewLine;

            return stringOrder;
        }

        private async Task SendOrderAsync(long managerId, Order order)
        {
            await _client.SendTextMessageAsync(managerId, OrderToStr(order));
        }

        public async Task SendAllAsync()
        {
            var managerIds = _userStorage.GetAllAdmins();
            var orders = _orderStorage.GetAll();
            foreach (var id in managerIds)
                foreach (var order in orders)
                    if (order.Ready)
                        await SendOrderAsync(id, order);
        }

        public async Task SendOrderToAllAsync(Order order)
        {
            var managerIds = _userStorage.GetAllAdmins();
            foreach (var id in managerIds)
                await SendOrderAsync(id, order);
        }

        public OrderSender(IOrderStorage orderStorage, IAdminStorage userStorage, TelegramBotClient client)
        {
            _orderStorage = orderStorage;
            _userStorage = userStorage;
            _client = client;
        }
    }
}
