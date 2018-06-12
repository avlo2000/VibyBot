using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using VibyBot.Persistence.Contracts;

namespace VibyBot.Control.AdminCommands
{
    public class RemovePrintCommand : AdminCommand
    {
        public override string Name => @"/rmprint";

        public async override Task ExecuteAsync(Message message, TelegramBotClient client)
        {
            var splCommand = message.Text.Split(' ');
            var chatId = message.Chat.Id;

            if (_adminStorage.GetAdminAccess(chatId))
            {
                _managerInfo.Prints.Remove(splCommand[1]);
                Answer = "Принт видалено.";
            }
            else
                Answer = "Немає дозволу.";

            _managementStorage.UpdateConfig(_managerInfo);
            await client.SendTextMessageAsync(chatId, Answer);
        }

        public RemovePrintCommand(IManagementStorage managementStorage, IAdminStorage userStorage, IOrderStorage orderStorage)
            : base(managementStorage, userStorage, orderStorage)
        {
        }
    }
}
