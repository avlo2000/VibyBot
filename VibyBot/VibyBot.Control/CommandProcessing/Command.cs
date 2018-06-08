using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using VibyBot.Control.Contracts;

namespace VibyBot.Control.CommandProcessing
{
    abstract public class Command
    {
        public abstract string Name { get; }

        public string Answer { get; protected set; }

        public IUserInfo UserInformation;

        abstract public void Execute(Message message, TelegramBotClient client);

        public virtual bool Contains(string command)
        {
            return command.Contains(Name);
        }
    }
}
