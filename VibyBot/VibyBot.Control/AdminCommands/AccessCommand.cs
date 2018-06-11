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
    //ця команда особлива, оскільки вона надає адмін доступ
    public class AccessCommand : Command
    {
        public override string Name => @"/admin";

        public async override Task Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            Answer = "Access allowed";

            //тут у випадку якщо юзеру надано доступ його записують в бд як адміна
            object locker = new object();
            if (Contains(message.Text))
                lock (locker)
                    UserInfo.SetAdminAccess(chatId);

            await client.SendTextMessageAsync(chatId, Answer);
        }

        public override bool Contains(string command)
        {
            return (command.Contains(Name) && command.Contains(_managerInfo.Password));
        }

        public AccessCommand(IManagementStorage managementStorage) : base(managementStorage)
        {
        }
    }
}
