using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using VibyBot.Control.ManagerConfiguration;

namespace VibyBot.Control.CommandProcessing
{
    //ця команда особлива, оскільки вона надає адмін доступ
    public class AccessCommand : Command
    {
        public override string Name => @"/admin";

        public override void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;

            //тут у випадку якщо юзеру надано доступ його записують в бд як адміна
            object locker = new object();
            if (Contains(message.Text))
                lock(locker)
                    UserInformation.SetAdminAccess(chatId);
                
            client.SendTextMessageAsync(chatId, Answer);
        }

        public override bool Contains(string command)
        {
            if (command.Contains(Name) && command.Contains(ManagerConfig.Password))
            {
                Answer = "Access allowed";
                return true;
            }
            else
            {
                Answer = "Access denied";
                return false;
            }
        }
    }
}
