using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using VibyBot.Persistence.ManagerConfiguration;

namespace VibyBot.Conrol.AdminCommands
{
    //ця команда особлива, оскільки вона надає адмін доступ
    public class AccessCommand : Command
    {
        public override string Name => @"/admin";

        public override void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            Answer = "Access allowed";

            //тут у випадку якщо юзеру надано доступ його записують в бд як адміна
            object locker = new object();
            if (Contains(message.Text))
                lock (locker)
                    UserInfo.SetAdminAccess(chatId);

            client.SendTextMessageAsync(chatId, Answer);
        }

        public override bool Contains(string command)
        {
            return (command.Contains(Name) && command.Contains(ManagerConfig.Password));
        }
    }
}
