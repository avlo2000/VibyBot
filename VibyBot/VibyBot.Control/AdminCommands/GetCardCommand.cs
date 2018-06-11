using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using VibyBot.Conrol;
using VibyBot.Persistence.ManagerConfiguration;

namespace VibyBot.Control.AdminCommands
{
    public class GetCardCommand : Command
    {
        public override string Name => @"/getcard";

        public override void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;

            if (UserInfo.GetAdminAccess(chatId))
                Answer = "Номер картки: " + ManagerConfig.CardNumber;
            else
                Answer = "Немає дозволу.";

            client.SendTextMessageAsync(chatId, Answer);
        }
    }
}
