using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using VibyBot.Persistence.Contracts;
using VibyBot.Persistence.DTO;

namespace VibyBot.Conrol.AdminCommands
{
    public class AddPrintCommand : AdminCommand
    {
        public override string Name => @"/addprint ";

        public async override Task Execute(Message message, TelegramBotClient client)
        {
            var splCommand = message.Text.Split(' ');
            var chatId = message.Chat.Id;

            if (UserInfo.GetAdminAccess(chatId))
            {
                _managerInfo.Prints.Add(splCommand[1]);
                Answer = "Принт додано.";
            }
            else
                Answer = "Немає дозволу.";

            _managementStorage.UpdateConfig(_managerInfo);
            await client.SendTextMessageAsync(chatId, Answer);
        }

        public AddPrintCommand(IManagementStorage managementStorage) : base(managementStorage)
        {
        }
    }
}
