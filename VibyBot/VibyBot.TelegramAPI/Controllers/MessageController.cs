using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Telegram.Bot.Types;
using TelegramInteractionPOC.Services;

namespace VibyBot.TelegramAPI.Controllers
{
    public class MessageController : ApiController
    {
        private IMessageService _messageService;

        public MessageController()
        {
            _messageService = new MessageService();
        }

        [Route(@"api/message/update")]
        public async Task<OkResult> Update([FromBody]Update update)
        {
            await _messageService.Execute(update);
            return Ok();
        }
    }
}
