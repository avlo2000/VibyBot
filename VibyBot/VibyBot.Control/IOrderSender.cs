using System.Threading.Tasks;
using VibyBot.Persistence.DTO;

namespace VibyBot.Control
{
    public interface IOrderSender
    {
        Task SendOrderToAllAsync(Order order);
    }
}
