using System.Threading.Tasks;
using System.Web.Http;
using Telegram.Bot.Types;
using VibyBot.Persistence.Contracts;

namespace TelegramInteractionPOC.Services
{
    public interface IMessageService
    {
        Task Execute([FromBody]Update update, IManagementStorage managementStorage, IAdminStorage adminStorage, IOrderStorage orderStorage);
    }
}
