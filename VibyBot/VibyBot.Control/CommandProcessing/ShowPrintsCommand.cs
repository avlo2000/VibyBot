using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using VibyBot.Control.ManagerConfiguration;

namespace VibyBot.Control.CommandProcessing
{
    public class ShowPrintsCommand : Command
    {
        public override string Name => @"/showprints";

        public override void Execute(Message message, TelegramBotClient client)
        {
            Answer = "Дотупні принти:\n";
            var chatId = message.Chat.Id;

            foreach (var print in ManagerConfig.Prints)
            {
                Answer += print;
                Answer += "\n";
            }

            client.SendTextMessageAsync(chatId, Answer);
        }
    }
}
