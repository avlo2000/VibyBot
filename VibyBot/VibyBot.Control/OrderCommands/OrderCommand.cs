using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using VibyBot.Persistence.Contracts;

namespace VibyBot.Control.OrderCommands
{
    abstract public class OrderCommand
    {
        public abstract string Name { get; }

        abstract public Task Execute(Message message, TelegramBotClient client);

        public string Answer { get; protected set; }

        public virtual bool Contains(string command)
        {
            return command.Contains(Name);
        }
    }
}
