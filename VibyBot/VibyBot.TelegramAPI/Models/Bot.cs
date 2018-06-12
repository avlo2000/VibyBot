using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Telegram.Bot;
using VibyBot.Control.AdminCommands;
using VibyBot.Persistence.Contracts;

namespace VibyBot.TelegramAPI.Models
{
    public static class Bot
    {
        private static TelegramBotClient _client;
        private static List<AdminCommand> _adminCommandsList;

        public static IReadOnlyList<AdminCommand> AdminCommands { get => _adminCommandsList.AsReadOnly(); }

        public static void RegistateCommands(IManagementStorage managementStorage, IAdminStorage adminStorage, IOrderStorage orderStorage)
        {
            _adminCommandsList = new List<AdminCommand>();
            _adminCommandsList.Add(new AccessCommand(managementStorage, adminStorage, orderStorage));
            _adminCommandsList.Add(new AddPrintCommand(managementStorage, adminStorage, orderStorage));
            _adminCommandsList.Add(new ShowPrintsCommand(managementStorage, adminStorage, orderStorage));
            _adminCommandsList.Add(new RemovePrintCommand(managementStorage, adminStorage, orderStorage));
            _adminCommandsList.Add(new CloseOrderCommand(managementStorage, adminStorage, orderStorage));
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
    }
}