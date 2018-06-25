using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Telegram.Bot;
using VibyBot.Control;
using VibyBot.Control.AdminCommands;
using VibyBot.Control.OrderCommands;
using VibyBot.Persistence.Contracts;

namespace VibyBot.TelegramAPI.Models
{
    public static class Bot
    {
        private static TelegramBotClient _client;
        private static List<ICommand> _commandsList;

        public static IReadOnlyList<ICommand> Commands { get => _commandsList.AsReadOnly(); }

        public static void RegistateCommands(IManagementStorage managementStorage, IAdminStorage adminStorage, IOrderStorage orderStorage)
        {
            _commandsList = new List<ICommand>();
            //admin commands
            _commandsList.Add(new AccessCommand(managementStorage, adminStorage, orderStorage));
            _commandsList.Add(new AddPrintCommand(managementStorage, adminStorage, orderStorage));
            _commandsList.Add(new ShowPrintsCommand(managementStorage, adminStorage, orderStorage));
            _commandsList.Add(new RemovePrintCommand(managementStorage, adminStorage, orderStorage));
            _commandsList.Add(new CloseOrderCommand(managementStorage, adminStorage, orderStorage));
            //order commands
            _commandsList.Add(new StartCommand(managementStorage, orderStorage));
            _commandsList.Add(new ChooseTypeCommand(managementStorage, orderStorage));
            _commandsList.Add(new ChoosePrintCommand(managementStorage, orderStorage));
        }

        public static async Task<TelegramBotClient> GetAsync(IManagementStorage managementStorage, IAdminStorage adminStorage, IOrderStorage orderStorage)
        {
            if (_client != null)
                return _client;

            RegistateCommands(managementStorage, adminStorage, orderStorage);

            _client = new TelegramBotClient(AppSettings.Key);

            var webHook = string.Concat(AppSettings.Url, "api/message/update");
            await _client.SetWebhookAsync(webHook);

            return _client;
        }

        public static TelegramBotClient Get()
        {
            return _client;
        }
    }
}