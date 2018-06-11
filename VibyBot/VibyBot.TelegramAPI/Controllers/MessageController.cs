using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Telegram.Bot.Types;
using VibyBot.TelegramAPI.Models;

namespace VibyBot.TelegramAPI.Controllers
{
    public class MessageController : ApiController
    {
        [Route(@"api/message/update")]
        public async Task<OkResult> Update([FromBody]Update update)
        {
            var adminCommands = Bot.AdminCommands;
            var message = update.Message;
            var client = await Bot.GetAsync(/*there  must be given implementation for IManagementStorage*/);
            foreach(var command in adminCommands)
                if (command.Contains(message.Text))
                {
                    await command.Execute(message, client);
                    break;
                }

            //TO DO
            return Ok();
        }
    }
}
