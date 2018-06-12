using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using VibyBot.Persistence.Contracts;

namespace VibyBot.Control.AdminCommands
{
    public class AddPrintCommand : AdminCommand
    {
        public override string Name => @"/addprint ";

        public async override Task ExecuteAsync(Message message, TelegramBotClient client)
        {
            var splCommand = message.Text.Split(' ');
            var chatId = message.Chat.Id;

            if (_adminStorage.GetAdminAccess(chatId))
            {
                _managerInfo.Prints.Add(splCommand[1]);
                Answer = "Принт додано.";
            }
            else
                Answer = "Немає дозволу.";

            _managementStorage.UpdateConfig(_managerInfo);
            await client.SendTextMessageAsync(chatId, Answer);
        }

        public AddPrintCommand(IManagementStorage managementStorage, IAdminStorage userStorage, IOrderStorage orderStorage)
            : base(managementStorage, userStorage, orderStorage)
        {
        }
    }
}
