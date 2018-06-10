using Telegram.Bot;
using Telegram.Bot.Types;
using VibyBot.Persistence.ManagerConfiguration;

namespace VibyBot.Conrol.AdminCommands
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
