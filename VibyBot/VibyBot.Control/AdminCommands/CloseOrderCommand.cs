using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using VibyBot.Persistence.Contracts;

namespace VibyBot.Control.AdminCommands
{
    public class CloseOrderCommand : AdminCommand
    {
        public override string Name => throw new NotImplementedException();

        public override Task ExecuteAsync(Message message, TelegramBotClient client)
        {
            throw new NotImplementedException();
        }

        public CloseOrderCommand(IManagementStorage managementStorage, IAdminStorage userStorage, IOrderStorage orderStorage)
            : base(managementStorage, userStorage, orderStorage)
        {
        }
    }
}
