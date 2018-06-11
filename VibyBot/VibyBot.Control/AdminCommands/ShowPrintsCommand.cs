using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using VibyBot.Persistence.Contracts;
using VibyBot.Persistence.DTO;

namespace VibyBot.Conrol.AdminCommands
{
    public class ShowPrintsCommand : AdminCommand
    {
        public override string Name => @"/showprints";

        public async override Task Execute(Message message, TelegramBotClient client)
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

        public ShowPrintsCommand(IManagementStorage managementStorage) : base(managementStorage)
        {
        }
    }
}
