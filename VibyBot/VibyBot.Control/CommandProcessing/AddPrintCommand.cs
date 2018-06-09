using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using VibyBot.Persistence.ManagerConfiguration;

namespace VibyBot.Persistence.CommandProcessing
{
    public class AddPrintCommand : Command
    {
        public override string Name => @"/addprint ";

        public override void Execute(Message message, TelegramBotClient client)
        {
            var splCommand = message.Text.Split(' ');
            var chatId = message.Chat.Id;

            if (UserInformation.GetAdminAccess(chatId))
            {
                ManagerConfig.Prints.Add(splCommand[1]);
                Answer = "Принт додано.";
            }
            else
                Answer = "Немає дозволу.";

            client.SendTextMessageAsync(chatId, Answer);
        }
    }
}
