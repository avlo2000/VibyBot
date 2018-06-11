using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Telegram.Bot;
using VibyBot.Conrol;
using VibyBot.Conrol.AdminCommands;

namespace VibyBot.TelegramAPI.Models
{
    public static class Bot
    {
        private static TelegramBotClient _client;
        private static List<Command> _commandsList;

        public static IReadOnlyList<Command> Commands { get => _commandsList.AsReadOnly(); }

        public static void RegistateCommands()
        {
            _commandsList = new List<Command>();
            _commandsList.Add(new AccessCommand());
            _commandsList.Add(new SetCardCommand());
            _commandsList.Add(new AddPrintCommand());
            _commandsList.Add(new ShowPrintsCommand());
        }

        public static async Task<TelegramBotClient>GetAsync()
        {
            if (_client != null)
                return _client;

            RegistateCommands();

            _client = new TelegramBotClient(AppSettings.Key);

            var webHook = string.Concat(AppSettings.Url, "api/message/update");
            await _client.SetWebhookAsync(webHook);

            return _client;
        }
    }
}