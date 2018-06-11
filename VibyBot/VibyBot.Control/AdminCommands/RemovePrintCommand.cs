using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using VibyBot.Conrol;

namespace VibyBot.Control.AdminCommands
{
    public class RemovePrintCommand : Command
    {
        public override string Name => @"/rmprint";

        public override void Execute(Message message, TelegramBotClient client)
        {
            throw new NotImplementedException();
        }
    }
}
