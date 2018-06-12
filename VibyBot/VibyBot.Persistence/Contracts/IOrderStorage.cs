using System.Collections.Generic;
using VibyBot.Persistence.DTO;

namespace VibyBot.Persistence.Contracts
{
    public interface IOrderStorage
    {
        void UpdateOrder(Order order);

        void CloseOrder(long orderId);

        IEnumerable<Order> CurrentOrders(long userId);

        IEnumerable<Order> GetAll();
    }
}
