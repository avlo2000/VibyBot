using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using VibyBot.Persistence.Contracts;

namespace VibyBot.Control.AdminCommands
{
    public class ShowPrintsCommand : AdminCommand
    {
        public override string Name => @"/showprints";

        public async override Task ExecuteAsync(Message message, TelegramBotClient client)
        {
            Answer = "Дотупні принти:" + Environment.NewLine;
            var chatId = message.Chat.Id;

            foreach (var print in _managerInfo.Prints)
            {
                Answer += print;
                Answer += Environment.NewLine;
            }

            await client.SendTextMessageAsync(chatId, Answer);
        }

        public ShowPrintsCommand(IManagementStorage managementStorage, IAdminStorage userStorage, IOrderStorage orderStorage)
            : base(managementStorage, userStorage, orderStorage)
        {
        }
    }
}
