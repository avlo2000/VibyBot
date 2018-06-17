using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Telegram.Bot.Types;
using VibyBot.Persistence.Contracts;
using VibyBot.TelegramAPI.Models;

namespace TelegramInteractionPOC.Services
{
    public class MessageService : IMessageService
    {
        public async Task Execute([FromBody]Update update)
        {
            var client = Bot.Get();
            var adminCommands = Bot.AdminCommands;
            var message = update.Message;
            foreach (var command in adminCommands)
                if (command.Contains(message.Text))
                {
                    string answer = command.Execute(message.Text, message.Chat.Id);
                    await client.SendTextMessageAsync(message.Chat, answer);
                    break;
                }
        }
    }
}