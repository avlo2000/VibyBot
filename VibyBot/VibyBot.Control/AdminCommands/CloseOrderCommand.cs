using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using VibyBot.Persistence.Contracts;

namespace VibyBot.Control.AdminCommands
{
    public class CloseOrderCommand : AdminCommand
    {
        public override string Name => @"/close ";

        public async override Task ExecuteAsync(Message message, TelegramBotClient client)
        {
            var splCommand = message.Text.Split(' ');
            var chatId = message.Chat.Id;
            var orderId = int.Parse(splCommand[1]);

            if (_adminStorage.GetAdminAccess(chatId))
            {
                _orderStorage.CloseOrder(orderId);
                Answer = "Замовлення закрито.";
            }
            else
                Answer = "Немає дозволу.";

            await client.SendTextMessageAsync(chatId, Answer);
        }

        public CloseOrderCommand(IManagementStorage managementStorage, IAdminStorage userStorage, IOrderStorage orderStorage)
            : base(managementStorage, userStorage, orderStorage)
        {
        }
    }
}
