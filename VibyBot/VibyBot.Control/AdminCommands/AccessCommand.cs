using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using VibyBot.Persistence.Contracts;

namespace VibyBot.Control.AdminCommands
{
    //ця команда особлива, оскільки вона надає адмін доступ
    public class AccessCommand : AdminCommand
    {
        public override string Name => @"/admin";

        public async override Task ExecuteAsync(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            Answer = "Access allowed";

            //тут у випадку якщо юзеру надано доступ його записують в бд як адміна
            object locker = new object();
            if (Contains(message.Text))
                lock (locker)
                    _adminStorage.SetAdminAccess(chatId);

            await client.SendTextMessageAsync(chatId, Answer);
        }

        public override bool Contains(string command)
        {
            return (command.Contains(Name) && command.Contains(_managerInfo.Password));
        }

        public AccessCommand(IManagementStorage managementStorage, IAdminStorage userStorage, IOrderStorage orderStorage) 
            : base(managementStorage, userStorage, orderStorage)
        {
        }
    }
}
