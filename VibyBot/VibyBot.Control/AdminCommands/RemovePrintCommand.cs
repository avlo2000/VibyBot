using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using VibyBot.Conrol;
using VibyBot.Conrol.AdminCommands;
using VibyBot.Persistence.Contracts;
using VibyBot.Persistence.DTO;

namespace VibyBot.Control.AdminCommands
{
    public class RemovePrintCommand : AdminCommand
    {
        public override string Name => @"/rmprint";

        public async override Task Execute(Message message, TelegramBotClient client)
        {
            var splCommand = message.Text.Split(' ');
            var chatId = message.Chat.Id;

            if (UserInfo.GetAdminAccess(chatId))
            {
                _managerInfo.Prints.Remove(splCommand[1]);
                Answer = "Принт видалено.";
            }
            else
                Answer = "Немає дозволу.";

            _managementStorage.UpdateConfig(_managerInfo);
            await client.SendTextMessageAsync(chatId, Answer);
        }

        public RemovePrintCommand(IManagementStorage managementStorage) : base(managementStorage)
        {
        }
    }
}
