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
    public class RemovePrintCommand : Command
    {
        public override string Name => @"/rmprint";

        public override void Execute(Message message, TelegramBotClient client)
        {
            var splCommand = message.Text.Split(' ');
            var chatId = message.Chat.Id;

            if (UserInfo.GetAdminAccess(chatId))
            {
                ManagerConfig.Prints.Remove(splCommand[1]);
                Answer = "Принт видалено.";
            }
            else
                Answer = "Немає дозволу.";

            client.SendTextMessageAsync(chatId, Answer);
        }
    }
}
