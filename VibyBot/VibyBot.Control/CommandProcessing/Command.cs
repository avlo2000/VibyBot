using Telegram.Bot;
using Telegram.Bot.Types;
using VibyBot.Persistence.Contracts;

namespace VibyBot.Persistence.CommandProcessing
{
    abstract public class Command
    {
        public abstract string Name { get; }

        abstract public void Execute(Message message, TelegramBotClient client);

        public string Answer { get; protected set; }

        public IUserInfo UserInformation;

        public virtual bool Contains(string command)
        {
            return command.Contains(Name);
        }
    }
}
