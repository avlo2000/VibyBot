using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;
using VibyBot.Control;
using VibyBot.Control.AdminCommands;
using VibyBot.Persistence.Contracts;

namespace VibyBot.TelegramAPI.Models
{
    public static class Bot
    {
        private static TelegramBotClient _client;
        private static List<ICommand> _adminCommandsList;

        public static IReadOnlyList<ICommand> AdminCommands { get => _adminCommandsList.AsReadOnly(); }

        public static void RegistateCommands(IManagementStorage managementStorage, IAdminStorage adminStorage, IOrderStorage orderStorage)
        {
            object locker = new object();

            lock (locker)
            {
                _adminCommandsList = new List<ICommand>();
                _adminCommandsList.Add(new AccessCommand(managementStorage, adminStorage, orderStorage));
                _adminCommandsList.Add(new AddPrintCommand(managementStorage, adminStorage, orderStorage));
                _adminCommandsList.Add(new ShowPrintsCommand(managementStorage, adminStorage, orderStorage));
                _adminCommandsList.Add(new RemovePrintCommand(managementStorage, adminStorage, orderStorage));
                _adminCommandsList.Add(new CloseOrderCommand(managementStorage, adminStorage, orderStorage));
            }
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