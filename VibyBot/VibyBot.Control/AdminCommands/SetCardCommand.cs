using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using VibyBot.Persistence.ManagerConfiguration;

namespace VibyBot.Conrol.AdminCommands
{
    public class SetCardCommand : Command
    {
        public override string Name => "/setcard";

        public override void Execute(Message message, TelegramBotClient client)
        {
            var splCommand = message.Text.Split(' ');
            var chatId = message.Chat.Id;

            if (UserInfo.GetAdminAccess(chatId))
            {
                ManagerConfig.CardNumber = splCommand[1];
                Answer = "Встановлено новий номер картки " + ManagerConfig.CardNumber;
            }
            else
                Answer = "Немає дозволу.";

            client.SendTextMessageAsync(chatId, Answer);
        }
    }
}
