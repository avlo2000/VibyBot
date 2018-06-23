using System.Threading.Tasks;
using System.Web.Http;
using Telegram.Bot.Types;
using VibyBot.Control.AdminCommands;
using VibyBot.TelegramAPI.Models;

namespace TelegramInteractionPOC.Services
{
    public class MessageService : IMessageService
    {
        public async Task Execute([FromBody]Update update)
        {
            var client = Bot.Get();
            var adminCommands = Bot.Commands;
            var message = update.Message;
            foreach (var command in adminCommands)
            {
                if (command.Contains(message.Text) && command.GetType().BaseType == typeof(AdminCommand))
                {
                    string answer = command.Execute(message.Text, message.Chat.Id);
                    await client.SendTextMessageAsync(message.Chat, answer);
                    break;
                }
            }
        }
    }
}