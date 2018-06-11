using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Telegram.Bot;
using VibyBot.Conrol;
using VibyBot.Conrol.AdminCommands;
using VibyBot.Persistence.Contracts;

namespace VibyBot.TelegramAPI.Models
{
    public static class Bot
    {
        private static TelegramBotClient _client;
        private static List<AdminCommand> _adminCommandsList;

        public static IReadOnlyList<AdminCommand> AdminCommands { get => _adminCommandsList.AsReadOnly(); }

        public static void RegistateCommands(IManagementStorage managementStorage)
        {
            _adminCommandsList = new List<AdminCommand>();
            _adminCommandsList.Add(new AccessCommand(managementStorage));
            _adminCommandsList.Add(new AddPrintCommand(managementStorage));
            _adminCommandsList.Add(new ShowPrintsCommand(managementStorage));
        }

        public static async Task<TelegramBotClient>GetAsync(IManagementStorage managementStorage)
        {
            if (_client != null)
                return _client;

            RegistateCommands(managementStorage);

            _client = new TelegramBotClient(AppSettings.Key);

            var webHook = string.Concat(AppSettings.Url, "api/message/update");
            await _client.SetWebhookAsync(webHook);

            return _client;
        }

        public static async Task<TelegramBotClient> GetAsync()
        {
            if (_client != null)
                return _client;

            _client = new TelegramBotClient(AppSettings.Key);

            var webHook = string.Concat(AppSettings.Url, "api/message/update");
            await _client.SetWebhookAsync(webHook);

            return _client;
        }
    }
}