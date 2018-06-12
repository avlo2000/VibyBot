using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Telegram.Bot.Types;
using TelegramInteractionPOC.Services;
using VibyBot.Persistence.Contracts;

namespace VibyBot.TelegramAPI.Controllers
{
    public class MessageController : ApiController
    {
        private IMessageService _messageService;
        private IManagementStorage _managementStorage;
        private IAdminStorage _userStorage;
        private IOrderStorage _orderStorage;

        public MessageController(IMessageService messageService, IManagementStorage managementStorage, IAdminStorage userStorage, IOrderStorage orderStorage)
        {
            _messageService = messageService;
            _managementStorage = managementStorage;
            _orderStorage = orderStorage;
            _userStorage = userStorage;
        }

        [Route(@"api/message/update")]
        public async Task<OkResult> Update([FromBody]Update update)
        {
            await _messageService.Execute(update, _managementStorage, _userStorage, _orderStorage);
            return Ok();
        }
    }
}
