using System.Collections.Generic;
using VibyBot.Persistence.DTO;

namespace VibyBot.Persistence.Contracts
{
    public interface IOrderStorage
    {
        void UpdateOrder(long userId, Order oreder);

        void CloseOrder(long userId);

        Order CurrentOrder(long userId);

        IEnumerable<Order> GetAll();
    }
}
